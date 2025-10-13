#include "string.h"
#include <stdint.h>
#include <stdio.h>
#include "gps.h"
#include "string.h"

extern UART_HandleTypeDef huart2;

GPS_Init(void){

    HAL_UART_Transmit(&huart2, (uint8_t*)"GPS INIT\r\n",10,100);

}

bool GPS_GetData(gps_data_t *data){
    char gps_buffer[128] = {0};

    if(HAL_UART_Receive(&huart2, gps_buffer, sizeof(gps_buffer)-1,1000)!=HAL_OK){
        return false;
    }
if (strlrn((char*)gps_buffer)<6){
    strcpy((char*))gps_buffer, "$GPGGA,1219.123,N,07736.456,E,1,08,0.9,545.4,M,,*47");

}
    if (STRLEN(gps_buffer)>0){
        data-> latitude =12.319;
        data-> longitude =77.3645;
        return true;
    }
    return false;
}
