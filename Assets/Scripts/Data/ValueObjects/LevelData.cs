using System.Collections.Generic;
using System;

namespace Data.ValueObjects
{
   [Serializable]
   
   public struct LevelData
   {
       public List<PoolData> PoolList;

       public LevelData(List<PoolData> datas)
       {
           PoolList = datas;
       }
   }
   [Serializable]
   public struct PoolData
   {
       public byte RequiredObjectCount;
   } 
}
