using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EvaluacionVoltron.Datos;
using static EvaluacionVoltron.Datos.AccessData;
using System.Drawing;
using EvaluacionVoltron.Clases;
using System.Drawing.Text;

namespace EvaluacionVoltron.Core
{
    internal class CoreEvaluacionVoltron
    {
        private AccessData dataAccess = new AccessData();

        public List<string> ConsultarDatos()
        {
            return dataAccess.ConsultarDatos();
        }
        //private List<Order> orders = new List<Order>();
        Order ord = new Order();
        public string insertapedido(double largo, double altura, string color)
        {
            AccessData db = new AccessData();
            var resp = "";
            

            try
            {
                var resdb = db.insertapedido(largo, altura, color);
                if (resdb != "1")
                {
                    resp = resdb;
                }
                else
                {
                    //Order orde = new Order(double.Parse(largo), double.Parse(altura), color);
                    resp = ord.GetOrderSummary(largo, altura, color);
                    //orders.Add(orde);

                }

            }
            catch (Exception ex)
            {
                resp = "Ocurrio un error: " + ex.Message;

            }
            return resp;
        }

        

    }
}
