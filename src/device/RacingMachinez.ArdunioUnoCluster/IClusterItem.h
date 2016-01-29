#ifndef IClusterItem_h
#define IClusterItem_h

#include "ClusterData.h"
#include "Enums.h"

class IClusterItem
{
    public:
        virtual ~IClusterItem() {};
        virtual boolean Hello() = 0;
        virtual void UpdateData(ClusterData clusterData) = 0;
};

#endif
