using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities
{
    public class ConverterDTO
    {
        public static T SimpleDTOConverter<T>(object obj) where T : new()
        {
            T dto = new T();
            foreach (var dtoProp in dto.GetType().GetProperties())
            {
                foreach (var objProp in obj.GetType().GetProperties())
                {
                    try
                    {
                        if (dtoProp.Name == objProp.Name)
                        {
                            object objValue = objProp.GetValue(obj);
                            //kada dodje navigacioni properti na red javlja se exception - ne moze da konvertuje u zahtevani tip
                            dtoProp.SetValue(dto, objValue);
                        }
                    }
                    catch (Exception) //kada se kod PUT metode uhvati exception i nastavi sa izvrsavanjem koda, na izlazu se dobija trazeni rezultat, kako???
                    // za GET ovo ipak ne funkcionise
                    {
                        continue;
                    }
                }
            }
            return dto;
        }
    }
}