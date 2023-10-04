/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2023 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "usb_device.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "math.h"
#include "ssd1306.h"
#include "fonts.h"
#include "mylan.h"
#include "modbus_crc.h"
#include "string.h"
#include "usbd_cdc_if.h"

#define FLASH_ADDR_PAGE_120 ((uint32_t)0x0800E012)
#define FLASH_ADDR_PAGE_121 ((uint32_t)0x0800E411)
#define FLASH_ADDR_PAGE_122 ((uint32_t)0x0800E810)
#define FLASH_ADDR_PAGE_123 ((uint32_t)0x0800EC10)
#define FLASH_ADDR_PAGE_124 ((uint32_t)0x0801F010)
#define FLASH_ADDR_PAGE_125 ((uint32_t)0x0801F410)
#define FLASH_ADDR_PAGE_126 ((uint32_t)0x0801F810)
#define FLASH_ADDR_PAGE_127 ((uint32_t)0x0801FC00)


#define FLASH_currentspeed_start_addr  FLASH_ADDR_PAGE_126
#define FLASH_currentspeed_end_addr  FLASH_ADDR_PAGE_127 + 0x400 - 0x01


#define FLASH_CW_start_addr FLASH_ADDR_PAGE_124
#define FLASH_CW_end_addr FLASH_ADDR_PAGE_125 + 0x400 - 0x01

#define FLASH_CCW_start_addr FLASH_ADDR_PAGE_122
#define FLASH_CCW_end_addr FLASH_ADDR_PAGE_123 + 0x400 - 0x01 

#define FLASH_BeingHome_start_addr FLASH_ADDR_PAGE_120
#define FLASH_BeingHome_end_addr FLASH_ADDR_PAGE_121 + 0x400 - 0x01 





/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
I2C_HandleTypeDef hi2c1;

TIM_HandleTypeDef htim1;
TIM_HandleTypeDef htim2;
TIM_HandleTypeDef htim3;

UART_HandleTypeDef huart1;

/* USER CODE BEGIN PV */
//uint32_t startpage = FLASH_currentspeed__start_addr;
//uint32_t dataread;



int Coating_Menu_Flag = 0;
int Main_menu_flag = 0;
int Speed_menu_flag = 0;
int COF_menu_flag = 0;
int COF_Result_flag = 0;
int COF_Option_Flag = 0;
int COF_Zero_flag = 0;
int COF_Speed_flag = 0;
int COF_Distance_flag = 0;


//Stepper flags
int FWD_Running = 0;
int BWD_Running = 0;

int Coating_Menu_Chosen = 0; // 1: Frequency menu are chosing by the pointer
int COF_Menu_Chosen = 0;  // 1: COF measurament menu are chosing by the pointer

// button flags
int button_A;
int button_B;
int button_C;
int button_D;
int button_E;
int button_F;
int CW_limit = 0;
int CCW_limit = 0;
int CW_COF = 0;
int Stop_State = 1;

//PWM
int Period;


//USB CDC 
uint8_t RxBuffer[64];
uint8_t UsbTxData[8];
uint8_t UsbData[64];

//Freq variable


int T_Duty_Circle = 300;


// speed variables
float current_speed;
int speed = 1000;
int N_currentspeed;
int R_currentspeed;

float Accel_Speed = 0;

int N_SF;
int R_SF;
int N_KF;
int R_KF;

char V[10];
char R[10];

//Button debounce

uint32_t previousMillis = 0;
uint32_t currentMillis = 0;
uint32_t counterOutside = 0; //For testing only
uint32_t counterInside = 0; //For testing only

// COF Variable
uint8_t TxData[8];
uint8_t RxData[32];
uint8_t ZeroData[16];
uint8_t COFData[16];
uint8_t USBSF[8];
uint8_t USBKF[8];
uint8_t USBSD[8];

uint16_t *Data;
int weight = 0;
char strWeight[10];
int Static_peak_delay = 20; // after this, kinetic sample will start calculating
int idx = 0;
int COF_Time = 0;
int Data_Weight[3000];
int Data_Weight_Size = 0;
char Weight_Idx [5];
char K_F[2];
char S_F[2];
int AVG_Weight;
int Static_Weight;
int kinetic_Weight;
int Max_Weight[10];
int Max_Weight_Index[3];
int Max_Weight_idx;

int Stable_Weight_Val;
int Being_home = 0;

int COF_Speed_chosen = 1;
int COF_Distance_chosen = 0;
int COF_Zero_chosen = 0;

int COFPeriod = 3272;
int Speed_COF = 150;
int Distance_COF = 130;
int COF_Lasting;
char COF_Dis[1];

int std_deviation;
float s1;
int K_idx;

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_I2C1_Init(void);
static void MX_TIM1_Init(void);
static void MX_USART1_UART_Init(void);
static void MX_TIM2_Init(void);
static void MX_TIM3_Init(void);
/* USER CODE BEGIN PFP */

// a function to get microsecond
void delay_us (uint16_t us)
{
    __HAL_TIM_SET_COUNTER(&htim1,0);  // set the counter value a 0
    while (__HAL_TIM_GET_COUNTER(&htim1) < us);  // wait for the counter to reach the us input in the parameter
} 


//Flag declaration for each type of menu 
void resetbutton()
{
	button_A = 0;
	button_B = 0;
	button_C = 0;
	button_D = 0;
}

void Main_Menu()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 1;
	Speed_menu_flag = 0;
	COF_menu_flag = 0;
	COF_Result_flag = 0;
	COF_Option_Flag = 0;
}
void Speed_Menu()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 0;
	Speed_menu_flag = 1;
	COF_menu_flag = 0;
	COF_Result_flag = 0;
	COF_Option_Flag = 0;
	COF_Zero_flag = 0;
	COF_Speed_flag = 0;
	COF_Distance_flag = 0;
}
void COF_Menu()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 0;
	Speed_menu_flag = 0;
	COF_menu_flag = 1;
	COF_Result_flag = 0;
	COF_Option_Flag = 0;
	COF_Zero_flag = 0;
	COF_Speed_flag = 0;
	COF_Distance_flag = 0;
}
void Coating_Menu()
{
	Coating_Menu_Flag = 1;
	Main_menu_flag = 0;
	Speed_menu_flag = 0;
	COF_menu_flag = 0;
	COF_Result_flag = 0;
	COF_Option_Flag = 0;
	COF_Zero_flag = 0;
	COF_Speed_flag = 0;
	COF_Distance_flag = 0;
}
void COF_Result()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 0;
	Speed_menu_flag = 0;
	COF_menu_flag = 0;
	COF_Option_Flag = 0;
	COF_Result_flag = 1;
	COF_Zero_flag = 0;
	COF_Speed_flag = 0;
	COF_Distance_flag = 0;
}
void COF_Options()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 0;
	Speed_menu_flag = 0;
	COF_menu_flag = 0;
	COF_Result_flag = 0;
	COF_Option_Flag = 1;
	COF_Zero_flag = 0;
	COF_Speed_flag = 0;
	COF_Distance_flag = 0;
	
}
void COF_Zero()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 0;
	Speed_menu_flag = 0;
	COF_menu_flag = 0;
	COF_Result_flag = 0;
	COF_Option_Flag = 0;
	COF_Zero_flag = 1;
	COF_Speed_flag = 0;
	COF_Distance_flag = 0;
}
void COF_Speed()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 0;
	Speed_menu_flag = 0;
	COF_menu_flag = 0;
	COF_Result_flag = 0;
	COF_Option_Flag = 0;
	COF_Zero_flag = 0;
	COF_Speed_flag = 1;
	COF_Distance_flag = 0;
}
void COF_Distance()
{
	Coating_Menu_Flag = 0;
	Main_menu_flag = 0;
	Speed_menu_flag = 0;
	COF_menu_flag = 0;
	COF_Result_flag = 0;
	COF_Option_Flag = 0;
	COF_Zero_flag = 0;
	COF_Speed_flag = 0;
	COF_Distance_flag = 1;
}
//void default_F()
//{
//	
//}
void Coating_Speed_Monitor(float T)
{
//	T = T/100;
	N_currentspeed = T/10;
  R_currentspeed = fmod(T,10);
}
void COF_Speed_Monitor(float T)
{
//	T = T/100;
	N_currentspeed = T/1000;
  R_currentspeed = fmod(T,1000)/10;
}
void COF_Distance_Cal(float S, int V)
{
	COF_Lasting = (S/5)*(5/(V/(60*pow(10,3))));
	
}
void COF_Monitor(float SF, float KF)
{
//	SF = SF /1000;
//	KF = KF /1000;
	N_SF = SF/1000;
	R_SF = fmod(SF,1000);
	
	N_KF = KF/1000;
	R_KF = fmod(KF,1000);
}

void Cal_PWM_Period(float speed)
{
	///////////////////////////////////////////////////////////////
	// each turn of vitme equal to 5mm on journey
	// 500 pulse, we have 1 round rotating
	// duty circle = time deploy 5mm / the number of Duty_circle
	///////////////////////////////////////////////////////////////
	
	double t = (5/((speed)/(60*pow(10,6)))); //microsecond
	T_Duty_Circle = (t/4000) ;
	Period = (((T_Duty_Circle*pow(10,-6))*(72*pow(10,6)))/11);
	
	
}
void Cal_COF_Period(float speed)
{
	///////////////////////////////////////////////////////////////
	// each turn of vitme equal to 5mm on journey
	// 500 pulse, we have 1 round rotating
	// duty circle = time deploy 5mm / the number of Duty_circle
	///////////////////////////////////////////////////////////////
	
	double t = (5/((speed)/(60*pow(10,6)))); //microsecond
	T_Duty_Circle = (t/4000) ;
	COFPeriod = (((T_Duty_Circle*pow(10,-6))*(72*pow(10,6)))/11);
	
	
}

////////////////////////////////////////////////////////////////////////
///
///				EEPROM - FLASH save voletive variable
///
///
///
///////////////////////////////////////////////////////////////////////
void FLASH_WritePage(uint32_t startPage,uint32_t endPage, uint32_t data32)
{
	HAL_FLASH_Unlock();
	FLASH_EraseInitTypeDef EraseInit;
	EraseInit.TypeErase = FLASH_TYPEERASE_PAGES;
	EraseInit.PageAddress = startPage;
//	EraseInit.NbPages = 1;
	EraseInit.NbPages = (endPage - startPage + 0x01)/(FLASH_PAGE_SIZE);
	uint32_t PageError = 0;
	HAL_FLASHEx_Erase(&EraseInit,&PageError);
	HAL_FLASH_Program(FLASH_TYPEPROGRAM_WORD, startPage, data32);
	HAL_FLASH_Lock();
}

// Read addr and return val of the address to data variable 
uint32_t FLASH_ReadData32(uint32_t addr)
{
	uint32_t data = *(__IO uint32_t *)(addr);
	return data;
}

void Return_LimitSW_Status()
{
	if(CW_limit) 	// thoat ve man hinh default nhung van giu trang thai cong tac hanh trinh
					{
						button_E = 1;			
						FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,CW_limit);
					}
				else if(CCW_limit)
					{
						button_F = 1;
						FLASH_WritePage(FLASH_CCW_start_addr,FLASH_CCW_end_addr,CCW_limit);
					}
						else
							{
								button_E = 0;
								button_F = 0;
								CW_limit = 0;
								CCW_limit = 0;
								FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,CW_limit);
								FLASH_WritePage(FLASH_CCW_start_addr,FLASH_CCW_end_addr,CCW_limit);
							}
}
void test_1round()
{
	__HAL_TIM_SET_AUTORELOAD(&htim3,900-1);
	HAL_TIM_PWM_Start(&htim3,TIM_CHANNEL_3);
	HAL_Delay(100);
	HAL_TIM_PWM_Stop(&htim3, TIM_CHANNEL_3);
}


////////////////////////////////////////////////////////////////
//
//
//	HMI Handler
//
//
////////////////////////////////////////////////////////////////
void HMI_Main_Menu(_Bool Coating_function,_Bool COF_Measurament)
{
	SSD1306_GotoXY(18,0);
	SSD1306_Puts("COATING - COF",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	SSD1306_GotoXY(0,20);
	SSD1306_Puts("Coating Function",&Font_7x10,Coating_function);
	SSD1306_GotoXY(0,32);
	SSD1306_Puts("COF Measuarament",&Font_7x10,COF_Measurament);

//instruction	text
	SSD1306_GotoXY(0,52);
	SSD1306_Puts("a",&Font_7x10,0x00);
	SSD1306_GotoXY(7,52);
	SSD1306_Puts(":Up",&Font_7x10,0x01);
	
	SSD1306_GotoXY(32,52);
	SSD1306_Puts("b",&Font_7x10,0x00);
	SSD1306_GotoXY(39,52);
	SSD1306_Puts(":DWN",&Font_7x10,0x01);
	
	SSD1306_GotoXY(69,52);
	SSD1306_Puts("c",&Font_7x10,0x00);
	SSD1306_GotoXY(76,52);
	SSD1306_Puts(":<",&Font_7x10,0x01);
	
	SSD1306_GotoXY(92,52);
	SSD1306_Puts("d",&Font_7x10,0x00);
	SSD1306_GotoXY(99,52);
	SSD1306_Puts(":Ent",&Font_7x10,0x01);
	
	
	
	SSD1306_UpdateScreen();
}
//void COFHMI()
//{
////	SSD1306_Clear();
//	SSD1306_GotoXY(14,0);
//	SSD1306_Puts("COF Measurament",&Font_7x10,0x01);
//	SSD1306_GotoXY(0,11);
//	SSD1306_Puts("--------------------",&Font_7x10,0x01);
//	SSD1306_GotoXY(0,24);
//	SSD1306_Puts("COF= ",&Font_11x18,0x01);
//	sprintf (strWeight, "%d", weight);
//	if(weight<10)
//	{
//		SSD1306_GotoXY(55,24);
//		SSD1306_Puts("    ",&Font_11x18,0x01);
//		SSD1306_GotoXY(99,24);
//	}
//	if(weight>10 && weight<100)
//	{
//		SSD1306_GotoXY(55,24);
//		SSD1306_Puts("   ",&Font_11x18,0x01);
//		SSD1306_GotoXY(88,24);
//	}
//	else if (weight>100 && weight<1000)
//	{
//		SSD1306_GotoXY(55,24);
//		SSD1306_Puts("  ",&Font_11x18,0x01);
//		SSD1306_GotoXY(77,24);
//	}
//	else if (weight>1000 && weight<10000)
//	{
//		SSD1306_GotoXY(55,24);
//		SSD1306_Puts(" ",&Font_11x18,0x01);
//		SSD1306_GotoXY(66,24);
//	}
//	
//	SSD1306_Puts(strWeight ,&Font_11x18,0x01);
//	SSD1306_GotoXY(80,24);

//	
//	
//	SSD1306_GotoXY(0,52);
//	SSD1306_Puts("a",&Font_7x10,0x00);
//	SSD1306_GotoXY(7,52);
//	SSD1306_Puts(":",&Font_7x10,0x01);
//	
//	SSD1306_GotoXY(32,52);
//	SSD1306_Puts("b",&Font_7x10,0x00);
//	SSD1306_GotoXY(39,52);
//	SSD1306_Puts(":DWN",&Font_7x10,0x01);
//	
//	SSD1306_GotoXY(69,52);
//	SSD1306_Puts("c",&Font_7x10,0x00);
//	SSD1306_GotoXY(76,52);
//	SSD1306_Puts(":<",&Font_7x10,0x01);
//	
//	SSD1306_GotoXY(92,52);
//	SSD1306_Puts("d",&Font_7x10,0x00);
//	SSD1306_GotoXY(99,52);
//	SSD1306_Puts(":Ent",&Font_7x10,0x01);
//	
//	SSD1306_UpdateScreen();
//}
void HMI_Speed_Adjustment()
{
//	SSD1306_Clear();
	SSD1306_GotoXY(10,0);
	SSD1306_Puts("SPEED ADJUSTMENT",&Font_7x10,0x01);
	SSD1306_GotoXY(0,11);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	SSD1306_GotoXY(0,24);
	SSD1306_Puts("V=",&Font_11x18,0x01);
	
	
	Coating_Speed_Monitor(current_speed);
	SSD1306_GotoXY(34,24);
	sprintf(V, "%d", N_currentspeed ); //convert int to String type 
	SSD1306_Puts(V ,&Font_11x18,0x01);
	SSD1306_GotoXY(46,24);
	SSD1306_Puts(".",&Font_11x18,0x01);
	SSD1306_GotoXY(57,24);
	sprintf(R, "%d", R_currentspeed ); //convert int to String type 
	SSD1306_Puts(R ,&Font_11x18,0x01);
	SSD1306_GotoXY(79,24);
	SSD1306_Puts("m/min",&Font_11x18,0x01);
	
//	SSD1306_GotoXY(69,24);
//	SSD1306_Puts("m/min", &Font_11x18,0x01);
	
//	sprintf(F, "%d", speed[current_speed]); //convert int to String type 
//	SSD1306_Puts(F ,&Font_11x18,0x01);
	
	
	//instruction	text
	SSD1306_GotoXY(0,52);	
	SSD1306_Puts("a",&Font_7x10,0x00);
	SSD1306_GotoXY(7,52);
	SSD1306_Puts(":Up",&Font_7x10,0x01);
	
	SSD1306_GotoXY(32,52);
	SSD1306_Puts("b",&Font_7x10,0x00);
	SSD1306_GotoXY(39,52);
	SSD1306_Puts(":DWN",&Font_7x10,0x01);
	
	SSD1306_GotoXY(69,52);
	SSD1306_Puts("c",&Font_7x10,0x00);
	SSD1306_GotoXY(76,52);
	SSD1306_Puts(":<",&Font_7x10,0x01);
	
	SSD1306_GotoXY(92,52);
	SSD1306_Puts("d",&Font_7x10,0x00);
	SSD1306_GotoXY(99,52);
	SSD1306_Puts(":Ent",&Font_7x10,0x01);
	
	SSD1306_UpdateScreen();
}
	
void HMI_Coating()
{
	SSD1306_GotoXY(39,0);
	SSD1306_Puts("COATING",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	SSD1306_GotoXY(0,21);
	SSD1306_Puts("Click A: Run FWD",&Font_7x10,0x01);
	SSD1306_GotoXY(0,31);
	SSD1306_Puts("Click B: Run BWD",&Font_7x10,0x01);
	SSD1306_GotoXY(0,41);
	SSD1306_Puts("Click C: Stop/Back",&Font_7x10,0x01);
	SSD1306_GotoXY(0,51);
	SSD1306_Puts("Click D: Open Menu",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
}
void HMI_COF()
{
	SSD1306_GotoXY(14,0);
	SSD1306_Puts("COF Measurament",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	SSD1306_GotoXY(0,21);
	SSD1306_Puts("Click A: Set_Home",&Font_7x10,0x01);
	SSD1306_GotoXY(0,31);
	SSD1306_Puts("Click B: Run COF",&Font_7x10,0x01);
	SSD1306_GotoXY(0,41);
	SSD1306_Puts("Click C: Back",&Font_7x10,0x01);
	SSD1306_GotoXY(0,51);
	SSD1306_Puts("Click D: COF_Setup",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
}
void HMI_COF_Result()
	
{
	SSD1306_GotoXY(14,0);
	SSD1306_Puts("COF Measurament",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
//	SSD1306_GotoXY(0,0);
//	sprintf (strWeight, "%d", Stable_Weight_Val);
////	SSD1306_Puts("SWV= ",&Font_11x18,0x01);
////	SSD1306_GotoXY(55,0);
//	SSD1306_Puts(strWeight,&Font_11x18,0x01);
//	
//	SSD1306_GotoXY(0,24);
//	SSD1306_Puts("idx = ",&Font_11x18,0x01);
//	SSD1306_GotoXY(55,24);
//	sprintf (strWeight, "%d", idx);
//	SSD1306_Puts(strWeight ,&Font_11x18,0x01);
	SSD1306_GotoXY(0,24);
	SSD1306_Puts("S.F= ",&Font_11x18,0x01);
	SSD1306_GotoXY(55,24);
	sprintf(V, "%d", N_SF ); //convert int to String type 
	SSD1306_Puts(V ,&Font_11x18,0x01);
	SSD1306_GotoXY(66,24);
	SSD1306_Puts(".",&Font_11x18,0x01);
	if(R_SF > 100)
	{
		SSD1306_GotoXY(77,24);
		sprintf(R, "%d", R_SF ); //convert int to String type 
		SSD1306_Puts(R ,&Font_11x18,0x01);
	}
	if(R_SF < 100 && R_SF > 10)
	{
		SSD1306_GotoXY(77,24);
		SSD1306_Puts("0",&Font_11x18,0x01);
		SSD1306_GotoXY(88,24);
		sprintf(R, "%d", R_SF ); //convert int to String type 
		SSD1306_Puts(R ,&Font_11x18,0x01);
	}
		if(R_SF < 10)
	{
		SSD1306_GotoXY(77,24);
		SSD1306_Puts("00",&Font_11x18,0x01);
		SSD1306_GotoXY(99,24);
		sprintf(R, "%d", R_SF ); //convert int to String type 
		SSD1306_Puts(R ,&Font_11x18,0x01);
	}
	
	SSD1306_GotoXY(0,42);
	SSD1306_Puts("K.F= ",&Font_11x18,0x01);
	SSD1306_GotoXY(55,42);
	sprintf(V, "%d", N_KF ); //convert int to String type 
	SSD1306_Puts(V ,&Font_11x18,0x01);
	SSD1306_GotoXY(66,42);
	SSD1306_Puts(".",&Font_11x18,0x01);
	if (R_KF > 100)
	{
		SSD1306_GotoXY(77,42);
		sprintf(R, "%d", R_KF ); //convert int to String type 
		SSD1306_Puts(R ,&Font_11x18,0x01);
	}
	if (R_KF < 100 && R_KF > 10)
	{
		SSD1306_GotoXY(77,42);
		SSD1306_Puts("0" ,&Font_11x18,0x01);
		SSD1306_GotoXY(88,42);
		sprintf(R, "%d", R_KF ); //convert int to String type 
		SSD1306_Puts(R ,&Font_11x18,0x01);
	}
	if(R_KF < 10)
	{
		SSD1306_GotoXY(77,42);
		SSD1306_Puts("00" ,&Font_11x18,0x01);
		SSD1306_GotoXY(99,42);
		sprintf(R, "%d", R_KF ); //convert int to String type 
		SSD1306_Puts(R ,&Font_11x18,0x01);
	}
//	
	
	
	SSD1306_UpdateScreen();
	
}
void HMI_Home_Running()
{
	SSD1306_GotoXY(14,0);
	SSD1306_Puts("COF Measurament",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	

	SSD1306_GotoXY(25,24);
	SSD1306_Puts("SETTING",&Font_11x18,0x01);
	SSD1306_GotoXY(25,44);
	SSD1306_Puts("HOME...",&Font_11x18,0x01);
	SSD1306_UpdateScreen();	
}
void HMI_SetHome_Warning()
{
	SSD1306_GotoXY(14,0);
	SSD1306_Puts("COF Measurament",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	
	for(int i = 0; i < 5 ; i++)
	{
		SSD1306_GotoXY(25,24);
		SSD1306_Puts("SetHOME",&Font_11x18,0x01);
		SSD1306_GotoXY(36,44);
		SSD1306_Puts("First",&Font_11x18,0x01);
		SSD1306_UpdateScreen();
		HAL_Delay(500);
		SSD1306_GotoXY(25,24);
		SSD1306_Puts("                         ",&Font_11x18,0x01);
		SSD1306_GotoXY(36,44);
		SSD1306_Puts("                        ",&Font_11x18,0x01);
		SSD1306_UpdateScreen();
		HAL_Delay(100);	
		
	}
	
	
	
}
void HMI_Being_Home()
{
	SSD1306_GotoXY(14,0);
	SSD1306_Puts("COF Measurament",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	
	for(int i = 0; i < 5 ; i++)
	{
		SSD1306_GotoXY(25,24);
		SSD1306_Puts("You Are",&Font_11x18,0x01);
		SSD1306_GotoXY(25,44);
		SSD1306_Puts("At Home",&Font_11x18,0x01);
		SSD1306_UpdateScreen();
		HAL_Delay(500);
		SSD1306_GotoXY(25,24);
		SSD1306_Puts("                         ",&Font_11x18,0x01);
		SSD1306_GotoXY(25,44);
		SSD1306_Puts("                        ",&Font_11x18,0x01);
		SSD1306_UpdateScreen();
		HAL_Delay(100);	
		
	}
}
void HMI_COF_Options(_Bool Change_COF_Speed,_Bool Change_COF_Distance, _Bool Set_Zero)
{
	SSD1306_GotoXY(25,0);
	SSD1306_Puts("COF SETTING",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	SSD1306_GotoXY(0,20);
	SSD1306_Puts("Change COF Speed",&Font_7x10,Change_COF_Speed);
	SSD1306_GotoXY(0,32);
	SSD1306_Puts("Change Distance",&Font_7x10,Change_COF_Distance);
	SSD1306_GotoXY(0,44);
	SSD1306_Puts("Set Zero",&Font_7x10,Set_Zero);


	
	
	
	SSD1306_UpdateScreen();
}
void HMI_Set_Zero()
{
	SSD1306_GotoXY(25,0);
	SSD1306_Puts("SET ZERO",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	
	SSD1306_GotoXY(15,20);
	SSD1306_Puts("Make sure pull",&Font_7x10,0x01);
	SSD1306_GotoXY(15,32);
	SSD1306_Puts("Cable is loose",&Font_7x10,0x01);
	
	SSD1306_GotoXY(93,52);
	SSD1306_Puts("D:Yes",&Font_7x10,0x01);
	SSD1306_GotoXY(0,52);
	SSD1306_Puts("C:Back",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
}
void HMI_Zero_successful()
{
	SSD1306_GotoXY(22,0);
	SSD1306_Puts("NOTIFICATION",&Font_7x10,0x01);
	SSD1306_GotoXY(0,9);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	
	SSD1306_GotoXY(29,20);
	SSD1306_Puts("Successful",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(1000);
	SSD1306_GotoXY(29,20);
	SSD1306_Puts("Restarting",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts("",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts(".",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts("..",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts("...",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts("....",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts(".....",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts("......",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts(".......",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts("........",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts(".........",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);
	SSD1306_GotoXY(29,32);
	SSD1306_Puts("..........",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	HAL_Delay(500);

}
void HMI_COF_Speed()
{
	SSD1306_GotoXY(32,0);
	SSD1306_Puts("COF SPEED",&Font_7x10,0x01);
	SSD1306_GotoXY(0,11);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	SSD1306_GotoXY(0,24);
	SSD1306_Puts("V=",&Font_11x18,0x01);
	
	
	COF_Speed_Monitor(Speed_COF);
	SSD1306_GotoXY(34,24);
	sprintf(V, "%d", N_currentspeed ); //convert int to String type 
	SSD1306_Puts(V ,&Font_11x18,0x01);
	SSD1306_GotoXY(46,24);
	SSD1306_Puts(".",&Font_11x18,0x01);
	SSD1306_GotoXY(57,24);
	sprintf(R, "%d", R_currentspeed ); //convert int to String type 
	SSD1306_Puts(R ,&Font_11x18,0x01);
	SSD1306_GotoXY(82,32);
	SSD1306_Puts("m/min",&Font_7x10,0x01);
	
//	SSD1306_GotoXY(69,24);
//	SSD1306_Puts("m/min", &Font_11x18,0x01);
	
//	sprintf(F, "%d", speed[current_speed]); //convert int to String type 
//	SSD1306_Puts(F ,&Font_11x18,0x01);
	
	
	//instruction	text
	SSD1306_GotoXY(0,52);	
	SSD1306_Puts("a",&Font_7x10,0x00);
	SSD1306_GotoXY(7,52);
	SSD1306_Puts(":Up",&Font_7x10,0x01);
	
	SSD1306_GotoXY(32,52);
	SSD1306_Puts("b",&Font_7x10,0x00);
	SSD1306_GotoXY(39,52);
	SSD1306_Puts(":DWN",&Font_7x10,0x01);
	
	SSD1306_GotoXY(69,52);
	SSD1306_Puts("c",&Font_7x10,0x00);
	SSD1306_GotoXY(76,52);
	SSD1306_Puts(":<",&Font_7x10,0x01);
	
	SSD1306_GotoXY(92,52);
	SSD1306_Puts("d",&Font_7x10,0x00);
	SSD1306_GotoXY(99,52);
	SSD1306_Puts(":Ent",&Font_7x10,0x01);
	
	SSD1306_UpdateScreen();
}
void HMI_COF_Distance()
{
	SSD1306_GotoXY(32,0);
	SSD1306_Puts("COF DISTANCE",&Font_7x10,0x01);
	SSD1306_GotoXY(0,11);
	SSD1306_Puts("--------------------",&Font_7x10,0x01);
	SSD1306_GotoXY(0,24);
	SSD1306_Puts("S=",&Font_11x18,0x01);
	
	
	COF_Speed_Monitor(Speed_COF);
	SSD1306_GotoXY(34,24);
	sprintf(COF_Dis, "%d",Distance_COF ); //convert int to String type 
	SSD1306_Puts(COF_Dis ,&Font_11x18,0x01);

	SSD1306_GotoXY(84,32);
	SSD1306_Puts("mm",&Font_7x10,0x01);
	
	SSD1306_GotoXY(0,52);	
	SSD1306_Puts("a",&Font_7x10,0x00);
	SSD1306_GotoXY(7,52);
	SSD1306_Puts(":Up",&Font_7x10,0x01);
	
	SSD1306_GotoXY(32,52);
	SSD1306_Puts("b",&Font_7x10,0x00);
	SSD1306_GotoXY(39,52);
	SSD1306_Puts(":DWN",&Font_7x10,0x01);
	
	SSD1306_GotoXY(69,52);
	SSD1306_Puts("c",&Font_7x10,0x00);
	SSD1306_GotoXY(76,52);
	SSD1306_Puts(":<",&Font_7x10,0x01);
	
	SSD1306_GotoXY(92,52);
	SSD1306_Puts("d",&Font_7x10,0x00);
	SSD1306_GotoXY(99,52);
	SSD1306_Puts(":Ent",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
}

///////////////////////////////////////////////
//
//	Interrupt Callback
//
//
//////////////////////////////////////////////
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	HAL_UART_Receive_IT(&huart1, RxData, 7);
}

//void HAL_UARTEx_RxEventCallback(UART_HandleTypeDef *huart, uint16_t Size)
//{
//	
//  weight = RxData[3] << 8 | RxData [4];
//	Data[1] = RxData[5] << 8 | RxData [6];
//	Data[2] = RxData[7] << 8 | RxData [8];	
//	Data[3] = RxData [0];
//	Data[4] = RxData[10]<< 8 | RxData [11];
//}

// Button config
void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin)
{
  UNUSED(GPIO_Pin);
	currentMillis = HAL_GetTick();

  if (GPIO_Pin == GPIO_PIN_5 && (currentMillis - previousMillis > 100)) // FWD
	{
		button_A = 1;
		button_B = 0;
		button_C = 0;
		button_D = 0;
		button_F = 0;
		FWD_Running = 1;
		BWD_Running = 0;
//		FLASH_WritePage(FLASH_CCW_start_addr,FLASH_CCW_end_addr,CCW_limit);
		
		previousMillis = currentMillis;
	} 
	else if (GPIO_Pin == GPIO_PIN_4 && (currentMillis - previousMillis > 100)) // BWD
	{
		button_A = 0;
		button_B = 1;
		button_C = 0;
		button_D = 0;
		button_E = 0;
//		CW_limit = 0;
		FWD_Running = 0;
		BWD_Running = 1;
//		FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,CW_limit);
		
		
		previousMillis = currentMillis;
		
	}
	else if (GPIO_Pin == GPIO_PIN_3 && (currentMillis - previousMillis > 200)) //Stop button
	{
		button_A = 0;
		button_B = 0;
		button_C = 1;
		button_D = 0;
		button_E = 0;
		button_F = 0;
		FWD_Running = 0;
		BWD_Running = 0;
//		HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
//		FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,CW_limit);
//		FLASH_WritePage(FLASH_CCW_start_addr,FLASH_CCW_end_addr,CCW_limit);
		previousMillis = currentMillis;
	}
	else if (GPIO_Pin == GPIO_PIN_2 && (currentMillis - previousMillis > 200)) // Menu
	{
		button_A = 0;
		button_B = 0;
		button_C = 0;
		button_D = 1;
		button_E = 0;
		button_F = 0;
//		FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,CW_limit);
//		FLASH_WritePage(FLASH_CCW_start_addr,FLASH_CCW_end_addr,CCW_limit);
		previousMillis = currentMillis;

	}
	
	else if (GPIO_Pin == GPIO_PIN_6 && (currentMillis - previousMillis > 10)) // Journey switch
	{ 
		if(!HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_6))
		{			
			button_B = 0;
			FWD_Running = 0;
			CW_COF = 1;
			CW_limit = 1;			
			button_C = 0;
//	button_D = 0;
			button_E = 1;
//	button_F = 0;
			
		
//		FLASH_WritePage(FLASH_CCW_start_addr,FLASH_CCW_end_addr,button_E);
			FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,CW_limit);
			previousMillis = currentMillis;
		}
		if(HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_6))
		{
			
			button_E = 0;
			CW_COF = 0;
			CW_limit = 0;
		}
					

	}

	else if (GPIO_Pin == GPIO_PIN_7 &&  (currentMillis - previousMillis > 10))// Journey switch 2
	{
		if(!HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_7))
		{
//			Deceleration_Limit(Accel_Speed);
//			HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
			button_A = 0;
			BWD_Running = 0;
			CCW_limit = 1;
			
			button_C = 0;
//		button_D = 0;
//		button_E = 0;
			button_F = 1;
			

//		FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,button_F);
			FLASH_WritePage(FLASH_CCW_start_addr,FLASH_CCW_end_addr,CCW_limit);
			previousMillis = currentMillis;
		}				
		if(HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_7))
		{
			button_F = 0;
			CCW_limit = 0;
		}
				
	}
//	 else if(GPIO_Pin == GPIO_PIN_4)
//		 { //check interrupt for specific pin              
//        if(!HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_4))
//					{
//           
//					}
//        
//        if(!HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_4))
//					{
//            
//					}
//			}
}
void Run_Coating()
{
	__HAL_TIM_SET_COMPARE(&htim3,TIM_CHANNEL_3,Period/2);
	__HAL_TIM_SET_AUTORELOAD(&htim3,Period);
	HAL_TIM_PWM_Start(&htim3,TIM_CHANNEL_3);
}

void Acceleration(int Target_Speed)
{
	Accel_Speed = 0;
	for (int i = 0; i < 80 ; i++ )
	{
		if (Accel_Speed < Target_Speed)
		{
		Accel_Speed = Accel_Speed + (Target_Speed/80);
		Cal_PWM_Period(Accel_Speed);
		Run_Coating();
		HAL_Delay(1);
		}
	}
}

void Deceleration(int Target_Speed)
{
	Accel_Speed = Target_Speed;
	for (int i = 0; i < 80 ; i++ )
	{
		if (Accel_Speed > 0)
		{
		Accel_Speed = Accel_Speed - (Target_Speed/80);
		Cal_PWM_Period(Accel_Speed);
		Run_Coating();
		HAL_Delay(1);
		}
	}
}

void Deceleration_Limit(int Target_Speed)
{
	Accel_Speed = Target_Speed;
	for (int i = 0; i < 50 ; i++ )
	{
		if (Accel_Speed > 0)
		{
		Accel_Speed = Accel_Speed - (Target_Speed/50);
		Cal_PWM_Period(Accel_Speed);
		Run_Coating();
		HAL_Delay(1);
		}
	}
}



/*------------------------------------------------------------------------
COF Measurament function
1. send hex via Rs485 to W100
2. Uart IT detect hex feedback from W100
3. Read date in the hex recieved



*/
void Run_SetHome()
{
//	FWD_Running = 1;
	__HAL_TIM_SET_COMPARE(&htim3,TIM_CHANNEL_3,162/2);	// 162 is a result of 25us Duty Circle ~ 3000mm/s at speed
	__HAL_TIM_SET_AUTORELOAD(&htim3,162); 
	HAL_TIM_PWM_Start(&htim3,TIM_CHANNEL_3);
}

void SendData()
{
		TxData[0] = 0x01; //Slave ad
		TxData[1] = 0x03; //function hex for read holding the register
		TxData[2] = 0x00; 
		TxData[3] =	0x0A; // read 40011 	
		TxData[4] = 0x00;
		TxData[5] = 0x01; // the number of registers
		
		//Calculating CRC 
		uint16_t crc = crc16(TxData, 6);
		TxData[6] = crc&0xFF;
		TxData[7] = (crc>>8)&0xFF;	
		HAL_UART_Transmit(&huart1, TxData, 8, 1000);
}
void Send_Zero()
{
		ZeroData[0] = 0x01; //Slave ad
		ZeroData[1] = 0x10; //function hex for writing to the register
		ZeroData[2] = 0x00; 
		ZeroData[3] =	0x05; // write Reg 100
		ZeroData[4] = 0x00;
		ZeroData[5] = 0x01; // Val write
		ZeroData[6] = 0x02; // Val write
		ZeroData[7] = 0x00; // Val write
		ZeroData[8] = 0x64; // Val write
		//Calculating CRC 
		uint16_t crc = crc16(ZeroData, 9);
		ZeroData[9] = crc&0xFF;
		ZeroData[10] = (crc>>8)&0xFF;	
		HAL_UART_Transmit(&huart1, ZeroData, 11, 1000);
}
void Run_COF()
{
	__HAL_TIM_SET_COMPARE(&htim3,TIM_CHANNEL_3,COFPeriod/2);
	__HAL_TIM_SET_AUTORELOAD(&htim3,COFPeriod);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_3);
}

void SetHome()
{	
	HAL_GPIO_WritePin(GPIOB,GPIO_PIN_1, GPIO_PIN_SET);
//	resetbutton();
	if(!CW_COF) 		Acceleration(3000);
	while (!CW_COF)
	{
		if(button_C)
		{
			CW_COF = 1;
		}	
		Run_SetHome();
	}
	Deceleration_Limit(Accel_Speed);
	HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
	HAL_Delay(400);	
	COF_Distance_Cal(Distance_COF,3000);	//delay to reduce noise and boucing limit switch
	if (!button_C)
	{
		HAL_GPIO_WritePin(GPIOB,GPIO_PIN_1, GPIO_PIN_RESET);
		Acceleration(3000);
		Run_SetHome();
//		HAL_Delay(100);	
		button_E = 0;
		CW_limit = 0;
		CCW_limit = 0;
		CW_COF = 0;
		FLASH_WritePage(FLASH_CW_start_addr,FLASH_CW_end_addr,CW_limit);
		HAL_Delay(COF_Lasting - 150);		//Home_setting_time
		Deceleration(Accel_Speed);
		HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);		
		Being_home = 1;
		memset(COFData,0x00,8);						
		COFData[0] = 'S';
		COFData[1] = 'H';
		COFData[2] = '1';
		CDC_Transmit_FS(COFData,8);
		
		
		
	}
	else
	{
		CW_COF = 0;
		CCW_limit = 0;
		HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
	}	
}


/*--------------------------------------------------------------------------------------------------------
Des: This void is to determine what exacly the pointer and Interrupt service routine have done on each strigger

author: Khang tran
Date: 8/2/23

----------------------------------------------------------------------------------------------------------
*/
void Menu_handler()
{
	if(Main_menu_flag)
	{
		Main_Menu();
		HAL_Delay(200);
		while(Main_menu_flag)
			if(button_A && COF_Menu_Chosen)
			{
				HMI_Main_Menu(0x00,0x01);				// COF ==> Coating
				Coating_Menu_Chosen = 1; 
				COF_Menu_Chosen = 0;
				resetbutton();
				
			}
			else if(button_A && Coating_Menu_Chosen) // Keep Coating menu pointer
			{
				HMI_Main_Menu(0x00,0x01);
				Coating_Menu_Chosen = 1;
				COF_Menu_Chosen = 0;
				resetbutton();
			}
			else if(button_B && COF_Menu_Chosen)  // Keep COF menu pointer
			{
				HMI_Main_Menu(0x01,0x00);
				Coating_Menu_Chosen = 0;
				COF_Menu_Chosen = 1;
				resetbutton();
			}
			else if(button_B && Coating_Menu_Chosen)	// Coating ==> COF
			{
				HMI_Main_Menu(0x01,0x00);
				Coating_Menu_Chosen = 0;
				COF_Menu_Chosen = 1;
				resetbutton();
			}
			else if(button_D && Coating_Menu_Chosen)
			{
				SSD1306_Clear();
				Coating_Menu();
//				// Return_LimitSW_Status();
				resetbutton();
			}
			else if(button_D && COF_Menu_Chosen)
			{
				SSD1306_Clear();
				COF_Menu();
//				// Return_LimitSW_Status();
				resetbutton();
			}
			
	}
	
// in this default menu, user are able to directly control the step motor VIA button A (CW) & button B (CCW) & button C to Stop
// Button D (menu) only be accessed in case of the stepper stopped ( CW flag and CCW flag == 0)
	
	
	if (Coating_Menu_Flag) // default menu access
	{
		SSD1306_Clear();
		HMI_Coating();
		Return_LimitSW_Status();		
		HAL_Delay(100);
		while(Coating_Menu_Flag)
		{
			if(button_D && Stop_State == 1) 
			{	
				SSD1306_Clear();
				Speed_Menu();
				resetbutton();
			}
			else if (button_A)
			{					
				if(!Stop_State)
				{
					Deceleration(Accel_Speed);
				}
				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_1, GPIO_PIN_SET);
				
//				FWD_Running = 1;
//				BWD_Running = 0;
//				button_A = 0;
				button_B = 0;
				button_C = 0;
				button_D = 0;
				button_F = 0;
				
				memset(COFData,0x00,8);					
				COFData[0] = 'S';
				COFData[1] = 'H';
				COFData[2] = '0';
				CDC_Transmit_FS(COFData,8);
				

				Acceleration(speed);
				Cal_PWM_Period(speed); // calculate PWM period time
				FLASH_WritePage(FLASH_BeingHome_start_addr, FLASH_BeingHome_end_addr, Being_home);
				while(FWD_Running)
				{	
					Run_Coating();
					Stop_State = 0;
					
					
					Being_home = 0;															
					
					HAL_Delay(1);
					CCW_limit = 0;	
					button_F = 0;
									
				}

			}
			
			else if (button_B)
			{			
				if(!Stop_State)
				{
					Deceleration(Accel_Speed);
				}
				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_1, GPIO_PIN_RESET);
//				FWD_Running = 0;
//				BWD_Running = 1;
				button_A = 0;
//				button_B = 0;
				button_C = 0; 
				button_D = 0;
				button_E = 0;
				
				//send stop state to winform
				memset(COFData,0x00,8);					
				COFData[0] = 'S';
				COFData[1] = 'H';
				COFData[2] = '0';
				CDC_Transmit_FS(COFData,8);
			
				Acceleration(speed);
				Cal_PWM_Period(speed); // calculate PWM period time
				FLASH_WritePage(FLASH_BeingHome_start_addr, FLASH_BeingHome_end_addr, Being_home);
				while(BWD_Running)
				{					
					Run_Coating();
					Stop_State = 0;
					Being_home = 0;						
					HAL_Delay(1);	
					CW_COF = 0;					
					CW_limit = 0;	
					button_E = 0;					
				}
			}
			else if (button_C && Stop_State)
			{
				SSD1306_Clear();
				HMI_Main_Menu(0x00,0x01);
				Coating_Menu_Chosen = 1;
				CW_COF = 0;
				if(CW_limit) CW_COF = 1; 
				Main_Menu();
				resetbutton();
			}
			else if (button_C && !Stop_State)
			{	
				Deceleration(Accel_Speed);
				Stop_State = 1;				
				FWD_Running = 0;
				BWD_Running = 0;
//				CCW_limit = 0;
//				CW_limit = 0;
				button_E = 0;
				button_F = 0;
				Return_LimitSW_Status();
				HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
				resetbutton();
			}
			
			else if (button_E)
			{
				Deceleration_Limit(Accel_Speed);
				HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
				FWD_Running = 0;
				CW_limit = 1;
//				button_A = 0;
				button_B = 0; 
				button_C = 0;
				button_D = 0;
				button_F = 0;
				Stop_State = 1;				
				memset(TxData, 0x00 ,sizeof(TxData)); //Send to winform state of motor
				TxData[0] = 'S';
				TxData[1] =	'S';
				CDC_Transmit_FS(TxData,2);
				while (button_E)
				{
					FWD_Running = 0;
					delay_us(50);
				}					
			}
			else if (button_F)
			{
				Deceleration_Limit(Accel_Speed);
				HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
				BWD_Running = 0;
				CCW_limit = 1;
				button_A = 0;
//				button_B = 0; 
				button_C = 0;
				button_D = 0;
				button_E = 0;
				Stop_State = 1;				
				memset(TxData, 0x00 ,sizeof(TxData));//Send to winform state of motor
				TxData[0] = 'S';
				TxData[1] =	'S';
				CDC_Transmit_FS(TxData,2);
				while (button_F)
				{
					BWD_Running = 0;
					delay_us(50);
				}					
			}
		}
	}
	
	
	if (Speed_menu_flag) // Speed adjustment menu access
	{
		SSD1306_Clear();
		HMI_Speed_Adjustment();
		HAL_Delay(100);
		while(Speed_menu_flag)
			{
				if(button_C)
				{
					SSD1306_Clear();
					Coating_Menu();
					// Return_LimitSW_Status();
					resetbutton();
				}
					
			
				if(button_A)
				{
					if(speed < 4000)
					{
						speed += 100;
						current_speed = speed / 100;
						Coating_Speed_Monitor(current_speed);
						FLASH_WritePage(FLASH_currentspeed_start_addr, FLASH_currentspeed_end_addr, speed);
						HMI_Speed_Adjustment();				
						resetbutton();
					} 
					else 
					{
						current_speed = speed / 100;
						Coating_Speed_Monitor(current_speed);
						FLASH_WritePage(FLASH_currentspeed_start_addr, FLASH_currentspeed_end_addr, speed);
						HMI_Speed_Adjustment();
						resetbutton();
					}
				}
				else if(button_B)
				{
					if(speed < 200)
					{
						current_speed = speed / 100;
						Coating_Speed_Monitor(current_speed);
						FLASH_WritePage(FLASH_currentspeed_start_addr, FLASH_currentspeed_end_addr, speed);
						HMI_Speed_Adjustment();
						resetbutton();
											
					}
					else
					{
						speed -= 100;			
						current_speed = speed / 100;
						Coating_Speed_Monitor(current_speed);
						FLASH_WritePage(FLASH_currentspeed_start_addr, FLASH_currentspeed_end_addr, speed);
						HMI_Speed_Adjustment();
						resetbutton();
					}
				}
				else if(button_D)
				{
					SSD1306_Clear();
					Coating_Menu();
					// Return_LimitSW_Status();
					resetbutton();
				}
			}
		}
 	if(COF_menu_flag) // COF monitor menu access
	{
		SSD1306_Clear();
		
		HMI_COF();
		HAL_Delay(100);
		while(COF_menu_flag)
		{
			
			if(button_A)
			{
				SSD1306_Clear();
				while(button_A)
				{	
					if(Being_home)
					{
									
						HMI_Being_Home();
						COF_Menu();
						HMI_COF();
						resetbutton();
					}
					else
					{
						
						HMI_Home_Running();
						HAL_GPIO_WritePin(GPIOB,GPIO_PIN_1, GPIO_PIN_SET);
						SetHome();
						
						
						
						FLASH_WritePage(FLASH_BeingHome_start_addr, FLASH_BeingHome_end_addr, Being_home);
						SSD1306_Clear();
						COF_Menu();
						HMI_COF();
						resetbutton();
					}
				}
			}
			
			if(button_B)
				{	
					SSD1306_Clear();	//clear Oled screen
					if(!Being_home)
					{
						HMI_SetHome_Warning();					
						COF_Menu();
						HMI_COF();
						resetbutton();
					}
					else if(Being_home)
					{
						
						
						memset(COFData,0x00,8);	
						COFData[0] = 'S';
						COFData[1] = 'I';
						CDC_Transmit_FS(COFData,sizeof(COFData));
						
						idx = 0;					
						Being_home = 0;
						
						
						// save and send home state
						FLASH_WritePage(FLASH_BeingHome_start_addr, FLASH_BeingHome_end_addr, Being_home);
						memset(COFData,0x00,8);						
						COFData[0] = 'S';
						COFData[1] = 'H';
						COFData[2] = '0';
						CDC_Transmit_FS(COFData,8);
						
						
						CW_COF = 0; 		// in case cw limit suddenly Open, this line will change the value					
						Static_Weight = 0;
						kinetic_Weight = 0;
						AVG_Weight = 0;
						Max_Weight[0] = 0;
						Max_Weight_Index[0] = 0;
						Max_Weight_idx = 0;
						Stable_Weight_Val = 0;						
						Max_Weight_idx = 0;
						s1 = 0;
						std_deviation = 0;
						weight = 0;
						memset(RxData,0x00,7);
						memset(Data_Weight,0x00,4000);
						SendData(); // Reset incoming RX value in the buffer
						HAL_GPIO_WritePin(GPIOB,GPIO_PIN_1, GPIO_PIN_SET);
						Run_COF();
						HAL_UART_Receive_IT(&huart1, RxData, 7);			// 8 bit -1 because stop bit auto add into serial data													
						while(!CW_COF)
							{
								if(button_C) CW_COF = 1;
								SendData();
								HAL_Delay(1);
								Stable_Weight_Val = 0;
								weight = RxData[3] << 8 | RxData [4];
								
								
								Data_Weight[idx] = weight;
								memset(COFData,0x00,8);
								sprintf((char*)UsbData,"%04X",weight);
								strcat((char*)COFData,"R");
								strcat((char*)COFData,(char*)UsbData);
								CDC_Transmit_FS(COFData,8);
					

	// SF - KF calculate
								Max_Weight[Max_Weight_idx] = Data_Weight[0];
								for(int i=0; i < idx; i++) // Fiding Static COF by detect Highest val of Weight data
									{	
										if (Max_Weight[Max_Weight_idx] < Data_Weight[i])
										{
											Max_Weight[Max_Weight_idx] = Data_Weight[i];
											Max_Weight_Index[Max_Weight_idx] = i;
										}
										else
										{
											Max_Weight_Index[Max_Weight_idx] = Max_Weight_Index[Max_Weight_idx];
											Max_Weight[Max_Weight_idx] = Max_Weight[Max_Weight_idx];
										}
									}
								for(int j = Max_Weight_Index[0] + Static_peak_delay; j < idx; j++)
									{
										Stable_Weight_Val = Stable_Weight_Val + Data_Weight[j];
									}
									
									AVG_Weight = Stable_Weight_Val / (idx - (Max_Weight_Index[0] + Static_peak_delay) ); // reality number of stable index
									Static_Weight = (Max_Weight[0]*10)/200;		//result of Static COF
									kinetic_Weight = (AVG_Weight*10)/200; 	//result of Kinetic COF
									COF_Monitor(Static_Weight,kinetic_Weight);
									
									// Find the 1st peak of weight
									if (idx - Max_Weight_Index[0] == Static_peak_delay && Max_Weight[Max_Weight_idx] > 1000)
									{
										Max_Weight_idx ++;
									}
									idx ++;
									HMI_COF_Result();
									
	 //end

							}
							for(int d = Max_Weight_Index[0] + Static_peak_delay; d < idx - 1; d++)
							{
								s1 = s1 + pow(Data_Weight[d]-(AVG_Weight),2);
							}
							std_deviation = (sqrt(s1/(idx - (Max_Weight_Index[0]+ Static_peak_delay) - 1))); 							//Standard deviation
							if(CW_limit) 
							{
								CW_COF = 1;
								HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);			
								SSD1306_Clear();
								COF_Result();
								resetbutton();	
							}
							else
							{
								CW_COF = 0;																																
								HAL_TIM_PWM_Stop(&htim3,TIM_CHANNEL_3);
								SSD1306_Clear();
								COF_Result();
								resetbutton();
							}
							memset(COFData,0x00,8);						
							sprintf((char*)USBSF,"%04X",Static_Weight);
							sprintf((char*)USBKF,"%04X",kinetic_Weight);
							sprintf((char*)USBSD,"%04X",std_deviation);				
							
							
							strcat((char*)COFData,"O");
							strcat((char*)COFData,(char*)USBSF);
							strcat((char*)COFData,(char*)USBKF);
							strcat((char*)COFData,(char*)USBSD);
							CDC_Transmit_FS(COFData,16);

					}
					resetbutton();
				}
			
			if(button_C)
			{
				SSD1306_Clear();
				HMI_Main_Menu(0x01,0x00);
				COF_Menu_Chosen = 1;
				Main_Menu();
				resetbutton();
			}
			
			if(button_D)
			{
				SSD1306_Clear();
				COF_Options();
				HMI_COF_Options(0,1,1);
				COF_Speed_chosen = 1;
				COF_Distance_chosen = 0;
				COF_Zero_chosen = 0;
				resetbutton();
			}
		}
	}
	if(COF_Result_flag)
	{
		HMI_COF_Result();
		if(button_C || button_D)
		{
			SSD1306_Clear();
			COF_Menu();
			resetbutton();
		}
		if(button_B)
		{
			
		}
	}
	///////////////////////////////////////////////////////////////////
	//
	//	This menu to setup everything related to COF measurament.
	//
	//
	///////////////////////////////////////////////////////////////////
	
	if(COF_Option_Flag)
	{
		COF_Options();
		if(button_A && COF_Speed_chosen)
		{
			COF_Speed_chosen = 1;
			COF_Distance_chosen = 0;
			COF_Zero_chosen = 0;
			HMI_COF_Options(0,1,1);
			resetbutton();
		}
		if(button_B && COF_Speed_chosen)
		{
			COF_Speed_chosen = 0;
			COF_Distance_chosen = 1;
			COF_Zero_chosen = 0;
			HMI_COF_Options(1,0,1);
			resetbutton();
		}
		if(button_A && COF_Distance_chosen)
		{
			COF_Speed_chosen = 1;
			COF_Distance_chosen = 0;
			COF_Zero_chosen = 0;
			HMI_COF_Options(0,1,1);
			resetbutton();
		}
		if(button_B && COF_Distance_chosen)
		{
			COF_Speed_chosen = 0;
			COF_Distance_chosen = 0;
			COF_Zero_chosen = 1;
			HMI_COF_Options(1,1,0);
			resetbutton();
			
		}
		if(button_A && COF_Zero_chosen)
		{
			COF_Speed_chosen = 0;
			COF_Distance_chosen = 1;
			COF_Zero_chosen = 0;
			HMI_COF_Options(1,0,1);
			resetbutton();
		}
		if(button_B && COF_Zero_chosen)
		{
			COF_Speed_chosen = 0;
			COF_Distance_chosen = 0;
			COF_Zero_chosen = 1;
			HMI_COF_Options(1,1,0);
			resetbutton();
		}
		if(button_C)
		{
			SSD1306_Clear();
			COF_Menu();
//				// Return_LimitSW_Status();
			resetbutton();
		}
		if(button_D && COF_Speed_chosen)
		{
			SSD1306_Clear();
			HMI_COF_Speed();
			COF_Speed();
			resetbutton();
			
		}
		if(button_D && COF_Distance_chosen)
		{
			SSD1306_Clear();
			HMI_COF_Distance();	
			COF_Distance();					
			resetbutton();
		}
		if(button_D && COF_Zero_chosen)
		{
			SSD1306_Clear();
			HMI_Set_Zero();
			COF_Zero();
			resetbutton();
		}
	}
	if(COF_Zero_flag)
	{
		COF_Zero();
		if(button_C)
		{
			SSD1306_Clear();
			COF_Options();
			HMI_COF_Options(1,1,0);
			COF_Speed_chosen = 0;
			COF_Distance_chosen = 0;
			COF_Zero_chosen = 1;
			resetbutton();		
		}
		if(button_D)
		{
			Send_Zero();
			SSD1306_Clear();
			HMI_Zero_successful();
			HAL_Delay(500);
			NVIC_SystemReset();
			resetbutton();
		}
	}
	if (COF_Speed_flag)
	{
		COF_Speed();
		
		Cal_COF_Period(Speed_COF);
		Coating_Speed_Monitor(Speed_COF);
		HMI_COF_Speed();
		if(button_A)
		{
			if(Speed_COF < 200)
			{
				Speed_COF += 50;
				Cal_COF_Period(current_speed);
				Coating_Speed_Monitor(Speed_COF);
				HMI_COF_Speed();
				resetbutton();
			}
			
		}
		if(button_B)
		{
			if(Speed_COF > 100)
			{
				Speed_COF -= 50;
				Cal_COF_Period(current_speed);
				Coating_Speed_Monitor(Speed_COF);
				HMI_COF_Speed();
				resetbutton();
			}
		}
		if(button_C)
		{
			SSD1306_Clear();
			COF_Options();
			HMI_COF_Options(0,1,1);
			COF_Speed_chosen = 1;
			COF_Distance_chosen = 0;
			COF_Zero_chosen = 0;
			resetbutton();
			
		}
		if(button_D)
		{
			SSD1306_Clear();
			COF_Options();
			HMI_COF_Options(0,1,1);
			COF_Speed_chosen = 1;
			COF_Distance_chosen = 0;
			COF_Zero_chosen = 0;
			resetbutton();
		}	
	}
	if(COF_Distance_flag)
	{
		COF_Distance();
		COF_Distance_Cal(Distance_COF,Speed_COF);
		HMI_COF_Distance();
		if(button_A)
		{
			if(Distance_COF < 200)
			{
				Distance_COF += 10;
				Being_home = 0;
				COF_Distance_Cal(Distance_COF,Speed_COF);
				HMI_COF_Distance();
				resetbutton();
			}
		}
		if(button_B)
		{
			if(Distance_COF > 130)
			{
				Distance_COF -= 10;
				Being_home = 0;
				COF_Distance_Cal(Distance_COF,Speed_COF);
				HMI_COF_Distance();
				resetbutton();
			}
		}
		if(button_C)
		{
			SSD1306_Clear();
			COF_Options();
			HMI_COF_Options(1,0,1);
			COF_Speed_chosen = 0;
			COF_Distance_chosen = 1;
			COF_Zero_chosen = 0;
			resetbutton();
		}
	}
}	




/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)

{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */
	
	
	
  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_I2C1_Init();
  MX_TIM1_Init();
  MX_USART1_UART_Init();
  MX_TIM2_Init();
  MX_TIM3_Init();
  MX_USB_DEVICE_Init();
  /* USER CODE BEGIN 2 */
//	HAL_UARTEx_ReceiveToIdle_IT(&huart1, RxData, 32);
	HAL_TIM_Base_Start(&htim1);	
	
//	FLASH_WritePage(FLASH_currentspeed__start_addr, FLASH_currentspeed_end_addr, 2000);
//	FLASH_WritePage(FLASH_currentspeed__start_addr,FLASH_currentspeed_end_addr,speed);
//	
//		FLASH_WritePage(FLASH_CW_start_addr, FLASH_CW_end_addr, 0x00);
//	FLASH_WritePage(FLASH_currentspeed__start_addr,FLASH_CW_end_addr,speed);
//	
//		FLASH_WritePage(FLASH_CCW_start_addr, FLASH_CCW_end_addr, 0x00);
//	FLASH_WritePage(FLASH_currentspeed__start_addr,FLASH_CCW_end_addr,speed);
	
	

	SSD1306_Init();
	SSD1306_Clear();
//	SSD1306_Fill(0x00);
//	SSD1306_UpdateScreen();
//	HAL_Delay(1000);
	SSD1306_DrawBitmap(34, 4, mylanlogo, 60, 32, 0x01);
	SSD1306_GotoXY(25,38);
	SSD1306_Puts("Formulating",&Font_7x10,0x01);
	SSD1306_GotoXY(8,52);
	SSD1306_Puts("A Greener World",&Font_7x10,0x01);
	SSD1306_UpdateScreen();
	
	
	
	CW_limit = FLASH_ReadData32(FLASH_CW_start_addr);
	HAL_Delay(100);
	CCW_limit = FLASH_ReadData32(FLASH_CCW_start_addr);
	HAL_Delay(100);
	speed = FLASH_ReadData32(FLASH_currentspeed_start_addr);
	
	Being_home = FLASH_ReadData32(FLASH_BeingHome_start_addr);

	
	current_speed = speed / 100;
	
	
	Coating_Speed_Monitor(current_speed);
//	HAL_Delay(5000);
	
	if(CW_limit) 
	{
		CW_COF = 1;
		button_E = 1;
	}
	if(CCW_limit) button_F = 1;
	SSD1306_Clear();
	HMI_Main_Menu(0,1);
	Coating_Menu_Chosen = 1;
	Main_Menu();	
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
		Menu_handler();
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.HSEPredivValue = RCC_HSE_PREDIV_DIV1;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL9;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_2) != HAL_OK)
  {
    Error_Handler();
  }
  PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_USB;
  PeriphClkInit.UsbClockSelection = RCC_USBCLKSOURCE_PLL_DIV1_5;
  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief I2C1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_I2C1_Init(void)
{

  /* USER CODE BEGIN I2C1_Init 0 */

  /* USER CODE END I2C1_Init 0 */

  /* USER CODE BEGIN I2C1_Init 1 */

  /* USER CODE END I2C1_Init 1 */
  hi2c1.Instance = I2C1;
  hi2c1.Init.ClockSpeed = 400000;
  hi2c1.Init.DutyCycle = I2C_DUTYCYCLE_2;
  hi2c1.Init.OwnAddress1 = 0;
  hi2c1.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
  hi2c1.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
  hi2c1.Init.OwnAddress2 = 0;
  hi2c1.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
  hi2c1.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
  if (HAL_I2C_Init(&hi2c1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN I2C1_Init 2 */

  /* USER CODE END I2C1_Init 2 */

}

/**
  * @brief TIM1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM1_Init(void)
{

  /* USER CODE BEGIN TIM1_Init 0 */

  /* USER CODE END TIM1_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM1_Init 1 */

  /* USER CODE END TIM1_Init 1 */
  htim1.Instance = TIM1;
  htim1.Init.Prescaler = 72-1;
  htim1.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim1.Init.Period = 0xffff-1;
  htim1.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim1.Init.RepetitionCounter = 0;
  htim1.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_ENABLE;
  if (HAL_TIM_Base_Init(&htim1) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim1, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim1, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM1_Init 2 */

  /* USER CODE END TIM1_Init 2 */

}

/**
  * @brief TIM2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM2_Init(void)
{

  /* USER CODE BEGIN TIM2_Init 0 */

  /* USER CODE END TIM2_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM2_Init 1 */

  /* USER CODE END TIM2_Init 1 */
  htim2.Instance = TIM2;
  htim2.Init.Prescaler = 1000;
  htim2.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim2.Init.Period = 28800;
  htim2.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim2.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_ENABLE;
  if (HAL_TIM_Base_Init(&htim2) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim2, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim2, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM2_Init 2 */

  /* USER CODE END TIM2_Init 2 */

}

/**
  * @brief TIM3 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM3_Init(void)
{

  /* USER CODE BEGIN TIM3_Init 0 */

  /* USER CODE END TIM3_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};
  TIM_OC_InitTypeDef sConfigOC = {0};

  /* USER CODE BEGIN TIM3_Init 1 */

  /* USER CODE END TIM3_Init 1 */
  htim3.Instance = TIM3;
  htim3.Init.Prescaler = 10;
  htim3.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim3.Init.Period = 72;
  htim3.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim3.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_ENABLE;
  if (HAL_TIM_Base_Init(&htim3) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim3, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&htim3) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim3, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  if (HAL_TIM_PWM_ConfigChannel(&htim3, &sConfigOC, TIM_CHANNEL_3) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM3_Init 2 */

  /* USER CODE END TIM3_Init 2 */
  HAL_TIM_MspPostInit(&htim3);

}

/**
  * @brief USART1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART1_UART_Init(void)
{

  /* USER CODE BEGIN USART1_Init 0 */

  /* USER CODE END USART1_Init 0 */

  /* USER CODE BEGIN USART1_Init 1 */

  /* USER CODE END USART1_Init 1 */
  huart1.Instance = USART1;
  huart1.Init.BaudRate = 115200;
  huart1.Init.WordLength = UART_WORDLENGTH_8B;
  huart1.Init.StopBits = UART_STOPBITS_1;
  huart1.Init.Parity = UART_PARITY_NONE;
  huart1.Init.Mode = UART_MODE_TX_RX;
  huart1.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart1.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART1_Init 2 */

  /* USER CODE END USART1_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOC_CLK_ENABLE();
  __HAL_RCC_GPIOD_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOC, GPIO_PIN_13|GPIO_PIN_14, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOB, GPIO_PIN_1, GPIO_PIN_RESET);

  /*Configure GPIO pins : PC13 PC14 */
  GPIO_InitStruct.Pin = GPIO_PIN_13|GPIO_PIN_14;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;
  HAL_GPIO_Init(GPIOC, &GPIO_InitStruct);

  /*Configure GPIO pins : PA2 PA3 PA4 PA5
                           PA6 PA7 */
  GPIO_InitStruct.Pin = GPIO_PIN_2|GPIO_PIN_3|GPIO_PIN_4|GPIO_PIN_5
                          |GPIO_PIN_6|GPIO_PIN_7;
  GPIO_InitStruct.Mode = GPIO_MODE_IT_FALLING;
  GPIO_InitStruct.Pull = GPIO_PULLUP;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pin : PB1 */
  GPIO_InitStruct.Pin = GPIO_PIN_1;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

  /* EXTI interrupt init*/
  HAL_NVIC_SetPriority(EXTI2_IRQn, 2, 0);
  HAL_NVIC_EnableIRQ(EXTI2_IRQn);

  HAL_NVIC_SetPriority(EXTI3_IRQn, 2, 0);
  HAL_NVIC_EnableIRQ(EXTI3_IRQn);

  HAL_NVIC_SetPriority(EXTI4_IRQn, 2, 0);
  HAL_NVIC_EnableIRQ(EXTI4_IRQn);

  HAL_NVIC_SetPriority(EXTI9_5_IRQn, 2, 0);
  HAL_NVIC_EnableIRQ(EXTI9_5_IRQn);

}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
