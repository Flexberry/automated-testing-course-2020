using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.FunctionalLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Sklad
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IDataService _dataService;

        public WarehouseService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public bool CanReserveProduct(Товар товар, int count)
        {
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(ТоварНаСкладе), ТоварНаСкладе.Views.ТоварНаСкладеD);
            lcs.LimitFunction = FunctionBuilder.BuildEquals<ТоварНаСкладе>(x => x.Товар, товар);
            var storeProducts = _dataService.LoadObjects(lcs).Cast<ТоварНаСкладе>();

            // ((SQLDataService)DataService).Query<ТоварНаСкладе>(ТоварНаСкладе.Views.ТоварНаСкладеD).Where(x => x.Товар == UpdatedObject.Товар).ToList();

            return storeProducts.Sum(x => x.Количество) > count;
        }

        public ТоварНаСкладе[] ReserveProduct(Товар товар, int count)
        {
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(ТоварНаСкладе), ТоварНаСкладе.Views.ТоварНаСкладеD);
            lcs.LimitFunction = FunctionBuilder.BuildEquals<ТоварНаСкладе>(x => x.Товар, товар);
            var storeProducts = _dataService.LoadObjects(lcs).Cast<ТоварНаСкладе>().ToList();

            List<ТоварНаСкладе> reservedProducts = new List<ТоварНаСкладе>();
            int i = 0;
            while (count > 0)
            {
                if (count >= storeProducts[i].Количество)
                {
                    count -= storeProducts[i].Количество;
                    storeProducts[i].SetStatus(ICSSoft.STORMNET.ObjectStatus.Deleted);
                }
                else
                {
                    storeProducts[i].Количество -= count;
                    count = 0;
                }
                reservedProducts.Add(storeProducts[i]);

                i++;
            }

            return reservedProducts.ToArray();
        }

        // wrong version
        //public ТоварНаСкладе[] ReserveProduct(Товар товар, int count)
        //{
        //    LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(ТоварНаСкладе), ТоварНаСкладе.Views.ТоварНаСкладеD);
        //    lcs.LimitFunction = FunctionBuilder.BuildEquals<ТоварНаСкладе>(x => x.Товар, товар);
        //    var storeProducts = _dataService.LoadObjects(lcs).Cast<ТоварНаСкладе>().ToList();

        //    List<ТоварНаСкладе> reservedProducts = new List<ТоварНаСкладе>();
        //    int i = 0;
        //    while (count > 0)
        //    {
        //        if (count >= storeProducts[i].Количество)
        //        {
        //            storeProducts[i].SetStatus(ICSSoft.STORMNET.ObjectStatus.Deleted);
        //        }
        //        else
        //        {
        //            storeProducts[i].Количество -= count;                    
        //        }
        //        reservedProducts.Add(storeProducts[i]);
        //        count -= storeProducts[i].Количество;
        //        i++;
        //    }

        //    return reservedProducts.ToArray();
        //}
    }
}
