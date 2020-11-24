using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace WebPrestamosUNED.app
{
    public class ConexionBD
    {
        #region Variables
        private SqlConnection _cnx;
        private String _cadenaConexion;
        #endregion

        #region Propiedades

        public String CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }

        #endregion

        #region Constructores

        public ConexionBD()
        {
            ObtenerConexion();
        }

        #endregion

        #region Metodos

        public string ObtenerConexion()
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["BDPrestamos"].ConnectionString;
            return _cadenaConexion;
        }

        public void Ejecutar(SqlCommand comando)
        {
            try
            {
                using (_cnx = new SqlConnection(CadenaConexion))
                {

                _cnx.Open();
                comando.Connection = _cnx;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.ExecuteNonQuery();

                _cnx.Close();
                }

            } catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_cnx != null)
                {
                    _cnx.Dispose();
                }

            }
        }
        #endregion
    }
}