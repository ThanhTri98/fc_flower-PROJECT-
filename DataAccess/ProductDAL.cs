using MyDataBase;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAL
    {
        FcFlowerADO aDO_FcFlower = new FcFlowerADO();
          public List<LoaiHoa> getLoaiHoa()
        {
            return aDO_FcFlower.LoaiHoa.ToList();
        }  
    }
}
