#ifndef IClusterItem_h
#define IClusterItem_h

#include "ClusterData.h"
#include "Enums.h"

class IClusterItem
{
    public:
        virtual ~IClusterItem() {};
        virtual boolean PerformInitialization() = 0;
        virtual void FinishInitialization() = 0;        
        virtual void UpdateData(ClusterData clusterData) = 0;
};

#endif
