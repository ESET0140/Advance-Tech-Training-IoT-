#ifndef DLMS_HANDLER_H
#define DLMS_HANDLER_H


#include <stdint.h>

typedef enum {
    DLMS_GET,
    DLMS_SET,
    DLMS_ACTION,
    DLMS_READ,
    DLMS_WRITE,
    DLMS_UNKNOWN

}dlms_request_type_t;


typedef struct {
    dlms_request_type_t type;
    uint32_t obis_code;
    uint8_t *payload;
    uint16_t length;
    
}dlms_request_type_t;

typedef struct{
    uint8_t data[256];
    uint16_t length;
} dlms_response_t;

void dlms_handler_init (void);
int dlms_process_request(dlms_request_t *req, dlms_response_t *resp);
void encrypt_response (uint8_t *data, uint_16_t len);
void decrypt_response (uint8_t *data, uint16_t len);
void DLMS_ProcessAPDU(uint8_t *apdu, size_t len);
void dlms_receive_handler(const uint8_t *payload, size_t len);
void send_response(uint8_t *data, size_t len);
bool DLMS_DecryptRequest(const uint8_t *input, size_t input_len, uint8_t *output, size_t max_output_len);

#endif

