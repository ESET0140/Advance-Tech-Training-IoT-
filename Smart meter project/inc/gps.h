#ifndef GPS_H
#define GPS_H

#include <stdint.h>
#include <stdbool.h>

typedef struct {
    float latitude;
    float longitude;

}gps_data_t;

void GPS_INIT(void);
bool GPS_GETData(gps_data_t *data)

#endif