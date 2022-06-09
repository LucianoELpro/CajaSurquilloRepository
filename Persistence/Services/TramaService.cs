using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class TramaService : ITramarService
    {
        
        public void Worker(List<CardRequest> requestList,List<TramaPosition> columnList)
        {

            //string[] stringLines = new string[requestList.Count]; 
            List<string> stringLines = new List<string>();

            CardRequest requestActual;

            for (int i = 0; i < requestList.Count; i++)
            {
                requestActual = requestList[i];
                StringBuilder line = new StringBuilder();

               // string datos = line.ToString();

                foreach (var column in columnList)
                {

                    var valor = requestActual.GetType().GetProperties().Single(pi => pi.Name == column.TramaName)
                                    .GetValue(requestActual, null).ToString();
                    var typeValue = column.TypeValue;
                    var defaulValue = column.Value;
                    var fullSpacePosition = column.fullSpacePosition;

                    line.Append(getDataTransform(valor, typeValue, defaulValue, fullSpacePosition));
                }

                //stringLines[i] = line.ToString();
                stringLines.Add(line.ToString());
            }

            //foreach (var property in listaProperties)
            //{
            //    foreach (var trama in tramaList)
            //    {
            //        if (property.Name.ToString().Equals(trama.TramaName))
            //        {
            //            property.Name.ToString().PadRight(trama.fullSpacePosition,trama.Value);


            //        }

            //    }
            //    stringLine.Append(property.Name);
            //}
            // ListLine.Add(stringLine.ToString());


            GetWriterString(stringLines);
        }

        String getDataTransform(string valor, string typeValue, string defaulValue, int fullSpacePosition) {
            String dato = "";
            string numeric = "N";
            //   0000000001
            if (typeValue == numeric)
            {
                dato = valor.PadLeft((fullSpacePosition), Convert.ToChar(defaulValue) );
            }
            else {
                dato = valor.PadRight((fullSpacePosition), Convert.ToChar(defaulValue));
            }

            return dato;
        }


        private void GetWriterString(List<String> Lista)
        {
            string path = @"C:\\2019\\Sample.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (var item in Lista)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
        }
      
    }




}
