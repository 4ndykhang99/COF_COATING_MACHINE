/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : usbd_cdc_if.c
  * @version        : v2.0_Cube
  * @brief          : Usb device for Virtual Com Port.
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
#include "usbd_cdc_if.h"

/* USER CODE BEGIN INCLUDE */
#include "main.h"
#include "ssd1306.h"
#include "math.h"
/* USER CODE END INCLUDE */

/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/

/* USER CODE BEGIN PV */
/* Private variables ---------------------------------------------------------*/

/* USER CODE END PV */

/** @addtogroup STM32_USB_OTG_DEVICE_LIBRARY
  * @brief Usb device library.
  * @{
  */

/** @addtogroup USBD_CDC_IF
  * @{
  */

/** @defgroup USBD_CDC_IF_Private_TypesDefinitions USBD_CDC_IF_Private_TypesDefinitions
  * @brief Private types.
  * @{
  */

/* USER CODE BEGIN PRIVATE_TYPES */
extern uint8_t RxBuffer[64];
extern int button_A;
extern int button_B;
extern int button_C;
extern int button_D;
extern int button_E;
extern int button_F;
extern int CW_limit;
extern int CCW_limit;
extern int CW_COF;
extern int Stop_State;
extern int speed;
extern float current_speed;

extern int N_currentspeed;
extern int R_currentspeed;


extern int FWD_Running;
extern int BWD_Running;

extern int Coating_Menu_Flag;
extern int Main_menu_flag ;
extern int Speed_menu_flag;
extern int COF_menu_flag ;
extern int COF_Result_flag;
extern int COF_Option_Flag;
extern int COF_Zero_flag;
extern int COF_Speed_flag;
extern int COF_Distance_flag;
extern int Being_home;
extern uint8_t COFData[8];


extern uint8_t UsbTxData[8];
extern uint8_t UsbData[64];
uint8_t USBSpeed[8];
uint8_t USBCOFSpeed[8];
uint8_t USBCOFD[8];
uint8_t USBBeingHome[8];

extern int Speed_COF;
extern int Distance_COF;

char SpeedBuffer[8];
char COFSpeed[8];
char COFDistance[8];
/* USER CODE END PRIVATE_TYPES */

/**
  * @}
  */

/** @defgroup USBD_CDC_IF_Private_Defines USBD_CDC_IF_Private_Defines
  * @brief Private defines.
  * @{
  */

/* USER CODE BEGIN PRIVATE_DEFINES */
/* USER CODE END PRIVATE_DEFINES */

/**
  * @}
  */

/** @defgroup USBD_CDC_IF_Private_Macros USBD_CDC_IF_Private_Macros
  * @brief Private macros.
  * @{
  */

/* USER CODE BEGIN PRIVATE_MACRO */

/* USER CODE END PRIVATE_MACRO */

/**
  * @}
  */

/** @defgroup USBD_CDC_IF_Private_Variables USBD_CDC_IF_Private_Variables
  * @brief Private variables.
  * @{
  */
/* Create buffer for reception and transmission           */
/* It's up to user to redefine and/or remove those define */
/** Received data over USB are stored in this buffer      */
uint8_t UserRxBufferFS[APP_RX_DATA_SIZE];

/** Data to send over USB CDC are stored in this buffer   */
uint8_t UserTxBufferFS[APP_TX_DATA_SIZE];

/* USER CODE BEGIN PRIVATE_VARIABLES */

/* USER CODE END PRIVATE_VARIABLES */

/**
  * @}
  */

/** @defgroup USBD_CDC_IF_Exported_Variables USBD_CDC_IF_Exported_Variables
  * @brief Public variables.
  * @{
  */

extern USBD_HandleTypeDef hUsbDeviceFS;


/* USER CODE BEGIN EXPORTED_VARIABLES */

/* USER CODE END EXPORTED_VARIABLES */

/**
  * @}
  */

/** @defgroup USBD_CDC_IF_Private_FunctionPrototypes USBD_CDC_IF_Private_FunctionPrototypes
  * @brief Private functions declaration.
  * @{
  */

static int8_t CDC_Init_FS(void);
static int8_t CDC_DeInit_FS(void);
static int8_t CDC_Control_FS(uint8_t cmd, uint8_t* pbuf, uint16_t length);
static int8_t CDC_Receive_FS(uint8_t* pbuf, uint32_t *Len);

/* USER CODE BEGIN PRIVATE_FUNCTIONS_DECLARATION */

/* USER CODE END PRIVATE_FUNCTIONS_DECLARATION */

/**
  * @}
  */

USBD_CDC_ItfTypeDef USBD_Interface_fops_FS =
{
  CDC_Init_FS,
  CDC_DeInit_FS,
  CDC_Control_FS,
  CDC_Receive_FS
};

/* Private functions ---------------------------------------------------------*/
/**
  * @brief  Initializes the CDC media low layer over the FS USB IP
  * @retval USBD_OK if all operations are OK else USBD_FAIL
  */
static int8_t CDC_Init_FS(void)
{
  /* USER CODE BEGIN 3 */
  /* Set Application Buffers */
  USBD_CDC_SetTxBuffer(&hUsbDeviceFS, UserTxBufferFS, 0);
  USBD_CDC_SetRxBuffer(&hUsbDeviceFS, UserRxBufferFS);
  return (USBD_OK);
  /* USER CODE END 3 */
}

/**
  * @brief  DeInitializes the CDC media low layer
  * @retval USBD_OK if all operations are OK else USBD_FAIL
  */
static int8_t CDC_DeInit_FS(void)
{
  /* USER CODE BEGIN 4 */
  return (USBD_OK);
  /* USER CODE END 4 */
}

/**
  * @brief  Manage the CDC class requests
  * @param  cmd: Command code
  * @param  pbuf: Buffer containing command data (request parameters)
  * @param  length: Number of data to be sent (in bytes)
  * @retval Result of the operation: USBD_OK if all operations are OK else USBD_FAIL
  */
static int8_t CDC_Control_FS(uint8_t cmd, uint8_t* pbuf, uint16_t length)
{
  /* USER CODE BEGIN 5 */
  switch(cmd)
  {
    case CDC_SEND_ENCAPSULATED_COMMAND:

    break;

    case CDC_GET_ENCAPSULATED_RESPONSE:

    break;

    case CDC_SET_COMM_FEATURE:

    break;

    case CDC_GET_COMM_FEATURE:

    break;

    case CDC_CLEAR_COMM_FEATURE:

    break;

  /*******************************************************************************/
  /* Line Coding Structure                                                       */
  /*-----------------------------------------------------------------------------*/
  /* Offset | Field       | Size | Value  | Description                          */
  /* 0      | dwDTERate   |   4  | Number |Data terminal rate, in bits per second*/
  /* 4      | bCharFormat |   1  | Number | Stop bits                            */
  /*                                        0 - 1 Stop bit                       */
  /*                                        1 - 1.5 Stop bits                    */
  /*                                        2 - 2 Stop bits                      */
  /* 5      | bParityType |  1   | Number | Parity                               */
  /*                                        0 - None                             */
  /*                                        1 - Odd                              */
  /*                                        2 - Even                             */
  /*                                        3 - Mark                             */
  /*                                        4 - Space                            */
  /* 6      | bDataBits  |   1   | Number Data bits (5, 6, 7, 8 or 16).          */
  /*******************************************************************************/
    case CDC_SET_LINE_CODING:

    break;

    case CDC_GET_LINE_CODING:

    break;

    case CDC_SET_CONTROL_LINE_STATE:

    break;

    case CDC_SEND_BREAK:

    break;

  default:
    break;
  }

  return (USBD_OK);
  /* USER CODE END 5 */
}

/**
  * @brief  Data received over USB OUT endpoint are sent over CDC interface
  *         through this function.
  *
  *         @note
  *         This function will issue a NAK packet on any OUT packet received on
  *         USB endpoint until exiting this function. If you exit this function
  *         before transfer is complete on CDC interface (ie. using DMA controller)
  *         it will result in receiving more data while previous ones are still
  *         not sent.
  *
  * @param  Buf: Buffer of data to be received
  * @param  Len: Number of data received (in bytes)
  * @retval Result of the operation: USBD_OK if all operations are OK else USBD_FAIL
  */
static int8_t CDC_Receive_FS(uint8_t* Buf, uint32_t *Len)
{
  /* USER CODE BEGIN 6 */
  USBD_CDC_SetRxBuffer(&hUsbDeviceFS, &Buf[0]);
  USBD_CDC_ReceivePacket(&hUsbDeviceFS);
	
	memset (RxBuffer, 0x00, 64);  // clear the buffer
  uint8_t len = (uint8_t)*Len;
  memcpy(RxBuffer, Buf, len);  // copy the data to the buffer
  memset(Buf, 0x00, len);   // clear the Buf also

	if (RxBuffer[0] == 'I') // Init value
	{
		//Coating Speed
		memset(UsbData,0x00,20);
		sprintf((char*)USBSpeed,"%04X",speed);
		sprintf((char*)USBCOFSpeed,"%04X",Speed_COF);
		sprintf((char*)USBCOFD,"%04X",Distance_COF);
		sprintf((char*)USBBeingHome,"%04X",Being_home);
		
		
		strcat((char*)UsbData,"L");
		strcat((char*)UsbData,(char*)USBSpeed);
		strcat((char*)UsbData,(char*)USBCOFSpeed);
		strcat((char*)UsbData,(char*)USBCOFD);
		strcat((char*)UsbData,(char*)USBBeingHome);
		
		int datasize = sizeof(UsbData)/sizeof(UsbData[0]);
		

		CDC_Transmit_FS((uint8_t *)UsbData,sizeof(UsbData));
		
		if(!Being_home)
		{
			memset(COFData,0x00,8);						
			COFData[0] = 'S';
			COFData[1] = 'H';
			COFData[2] = '0';
			CDC_Transmit_FS(COFData,8);
		}
		else if (Being_home)
		{
			memset(COFData,0x00,8);						
			COFData[0] = 'S';
			COFData[1] = 'H';
			COFData[2] = '1';
			CDC_Transmit_FS(COFData,8);
		}
	}
	if (RxBuffer[0] == 'F') //function
	{
		if (RxBuffer[1] == '1')
		{
			button_A = 1;
			button_B = 0;
			button_C = 0;
			button_D = 0;
			button_F = 0;
			FWD_Running = 1;
			BWD_Running = 0;
		}
		else if (RxBuffer[1] == '2')
		{
			button_A = 0;
			button_B = 1;
			button_C = 0;
			button_D = 0;
			button_E = 0;
			FWD_Running = 0;
			BWD_Running = 1;
		}
		else if (RxBuffer[1] == '3')
			{
				button_A = 0;
				button_B = 0;
				button_C = 1;
				button_D = 0;
				button_E = 0;
				button_F = 0;
				FWD_Running = 0;
				BWD_Running = 0;
			}
	}
	if (RxBuffer[0] == 'H') //HMI
	{
		SSD1306_Clear();
		
		if(RxBuffer[1] == '1')
		{		
			SSD1306_UpdateScreen();
			HMI_Coating();
			Coating_Menu();
		}
		if(RxBuffer[1] == '2')
		{
			SSD1306_UpdateScreen();	
			button_E = 0;
			button_F = 0;
			FWD_Running = 0;
			BWD_Running = 0;
			HMI_Coating();
			COF_Menu();
		}
		if(RxBuffer[1] == '3')
		{			
			SSD1306_UpdateScreen();
			HMI_Coating();
			COF_Menu();
		}
	}
	if (RxBuffer[0] == 'S') //Set value
	{
		
		if(RxBuffer[1] == 'S')
		{
			SSD1306_Clear();
			
			SpeedBuffer[0] = RxBuffer[2];
			SpeedBuffer[1] = RxBuffer[3];
			SpeedBuffer[2] = RxBuffer[4];
			SpeedBuffer[3] = RxBuffer[5];
			speed = strtof(SpeedBuffer, NULL);
			current_speed = speed / 100;
			Coating_Speed_Monitor(current_speed);
			HMI_Speed_Adjustment();
			
		}
		if(RxBuffer[1] == 'C')
		{
			
			SSD1306_Clear();
			
			COFSpeed[0] = RxBuffer[2];
			COFSpeed[1] = RxBuffer[3];
			COFSpeed[2] = RxBuffer[4];
			COFSpeed[3] = RxBuffer[5];
			
			COFDistance[0] = RxBuffer[6];
			COFDistance[1] = RxBuffer[7];
			COFDistance[2] = RxBuffer[8];
			COFDistance[3] = RxBuffer[9];
			
			Speed_COF = (int) strtol(COFSpeed, NULL, 16);
			Distance_COF = (int) strtol(COFDistance, NULL, 16);
			
			Cal_COF_Period(Speed_COF);
			COF_Distance_Cal(Distance_COF, Speed_COF);
//			SpeedBuffer[0] = RxBuffer[2];
//			SpeedBuffer[1] = RxBuffer[3];
//			SpeedBuffer[2] = RxBuffer[4];
//			SpeedBuffer[3] = RxBuffer[5];
//			speed = strtof(SpeedBuffer, NULL);
//			current_speed = speed / 100;
//			Coating_Speed_Monitor(current_speed);
//			HMI_Speed_Adjustment();
			
		}
	}
	
  return (USBD_OK);
  /* USER CODE END 6 */
}

/**
  * @brief  CDC_Transmit_FS
  *         Data to send over USB IN endpoint are sent over CDC interface
  *         through this function.
  *         @note
  *
  *
  * @param  Buf: Buffer of data to be sent
  * @param  Len: Number of data to be sent (in bytes)
  * @retval USBD_OK if all operations are OK else USBD_FAIL or USBD_BUSY
  */
uint8_t CDC_Transmit_FS(uint8_t* Buf, uint16_t Len)
{
  uint8_t result = USBD_OK;
  /* USER CODE BEGIN 7 */
  USBD_CDC_HandleTypeDef *hcdc = (USBD_CDC_HandleTypeDef*)hUsbDeviceFS.pClassData;
  if (hcdc->TxState != 0){
    return USBD_BUSY;
  }
  USBD_CDC_SetTxBuffer(&hUsbDeviceFS, Buf, Len);
  result = USBD_CDC_TransmitPacket(&hUsbDeviceFS);
  /* USER CODE END 7 */
  return result;
}

/* USER CODE BEGIN PRIVATE_FUNCTIONS_IMPLEMENTATION */

/* USER CODE END PRIVATE_FUNCTIONS_IMPLEMENTATION */

/**
  * @}
  */

/**
  * @}
  */
