using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebPrestamosUNED.app
{
    public class Prestamo
    {
        private double monto;

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        private double tasa;

        public double Tasa
        {
            get { return tasa; }
            set { tasa = value; }
        }

        private int plazo;

        public int Plazo
        {
            get { return plazo; }
            set { plazo = value; }
        }

        private int moneda;

        public int Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public Prestamo()
        {

        }

        public Prestamo(double _monto, double _tasa,int _plazo,int _moneda)
        {
            monto = _monto;
            tasa = _tasa;
            plazo = _plazo;
            moneda = _moneda;
        }

        public double Calculo_Cuota()
        {
            double resultado;
            double numerador;
            double denominador;
            double tasa_mensual;
            double plazo_mensual;

            tasa_mensual = (tasa / 100) / 12;
            plazo_mensual = plazo * 12;

            numerador = tasa_mensual * monto;
            denominador = 1 - (Math.Pow((1 + tasa_mensual), (-1 * plazo_mensual)));
            resultado = Math.Round(numerador / denominador, 0);

            return resultado;


        }

        public double Calculo_Intereses(double _monto)
        {
            return Math.Round(_monto * ((tasa / 100) / 12), 0);
        }

        public void Insertar_Prestamo()
        {
            try
            {
                ConexionBD Conn = new ConexionBD();
                DataTable dtPersonas = new DataTable();
                SqlCommand Command = new SqlCommand("inserta_calculo");

                SqlParameter p_monto = new SqlParameter("@monto", SqlDbType.Decimal);
                p_monto.Value = Convert.ToDecimal(Monto);
                p_monto.Direction = ParameterDirection.Input;
                Command.Parameters.Add(p_monto);

                SqlParameter p_tasa = new SqlParameter("@tasa_int", SqlDbType.Decimal);
                p_tasa.Value = Convert.ToDecimal(Tasa);
                p_tasa.Direction = ParameterDirection.Input;
                Command.Parameters.Add(p_tasa);

                SqlParameter p_plazo = new SqlParameter("@plazo", SqlDbType.Int);
                p_plazo.Value = Plazo;
                p_plazo.Direction = ParameterDirection.Input;
                Command.Parameters.Add(p_plazo);

                SqlParameter p_tipo_moneda = new SqlParameter("@tipo_moneda", SqlDbType.Int);
                p_tipo_moneda.Value = Moneda;
                p_tipo_moneda.Direction = ParameterDirection.Input;
                Command.Parameters.Add(p_tipo_moneda);

                SqlParameter p_tipo_cambio = new SqlParameter("@tipo_cambio", SqlDbType.Decimal);
                p_tipo_cambio.Value = Convert.ToDecimal("0");
                p_tipo_cambio.Direction = ParameterDirection.Input;
                Command.Parameters.Add(p_tipo_cambio);

                Conn.Ejecutar(Command);
            }


            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
    }
}