﻿using Core1.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//params verdiğim zaman Run metodu içerisine istediğim kadar parametre olarak IResult verebiliyorum.Gönderdiğimiz bütün parametreleri array haline getirip logics'e atanıyor.
        {
            foreach (var logic in logics)//logics : İş kurallarım.
            {
                if (!logic.Success)//Başarısız olan iş kuralım olursa
                {
                    return logic;//Mevcut hata varsa onu döndürür.
                }
            }
            return null;//tüm kurallarım başarılı ise null döndür.
        }
    }
}

