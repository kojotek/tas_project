using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiedaPL_BusAPI.Seeker
{
    class SimpleSeekManager<T> : ISeekManager<T>
    {
        static public T Find<T>(System.Data.Linq.ITable<T> table, T item, IComparer<T> cmp)
        {
            var list = table.Where(x => cmp.Compare(item, x) == 0).ToList();
            try
            {
                var result = list.First();
                return result;
            }
            catch (ArgumentNullException)
            {
                return default(T);
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }
        }

        static public bool FindAndDestroy<T>(System.Data.Linq.ITable<T> table, T item, IComparer<T> cmp)
        {
            var list = table.Where(x => cmp.Compare(x, item) == 0).ToList();
            try
            {
                var result = list.First();
                table.DeleteOnSubmit(result);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        static public T FindOrCreate<T>(System.Data.Linq.ITable<T> table, T item, IComparer<T> cmp)
        {
            var list = table.Where(x => cmp.Compare(x, item) == 0).ToList();
            try
            {
                var result = list.First();
                table.InsertOnSubmit(result);
                return result;
            }
            catch (ArgumentNullException)
            {
                var result = item;
                table.InsertOnSubmit(result);
                return result;
            }
            catch (InvalidOperationException)
            {
                var result = item;
                table.InsertOnSubmit(result);
                return result;
            }
        }

        static public T Find(System.Data.Linq.ITable<T> table, T lo, T hi, IComparer<T> cmp)
        {
            var list = table.Where(x => cmp.Compare(lo, x) <= 0 && cmp.Compare(hi, x) >= 0).ToList();

            try
            {
                var result = list.First();
                return result;
            }
            catch (ArgumentNullException)
            {
                return default(T);
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }
        }
    }
    }
}
