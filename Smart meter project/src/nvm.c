#include "nvm.h"
#include "stm32f3xx_hal.h"
#include <string.h>

#define NVM_BASE_ADDR  0x08080000  // EEPROM / Flash address

void NVM_Init(void) {
    // Setup EEPROM or Flash interface
}

void NVM_SaveGPS(const gps_data_t *data) {
    // Store in Flash or EEPROM
    // For demo, we just simulate write
    HAL_FLASH_Unlock();
    uint32_t *ptr = (uint32_t*)NVM_BASE_ADDR;
    HAL_FLASH_Program(FLASH_TYPEPROGRAM_WORD, (uint32_t)ptr, *(uint32_t*)&data->latitude);
    HAL_FLASH_Program(FLASH_TYPEPROGRAM_WORD, (uint32_t)(ptr+1), *(uint32_t*)&data->longitude);
    HAL_FLASH_Lock();
}