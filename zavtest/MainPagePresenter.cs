using System;
using System.Collections;
using System.Collections.Generic;
using zavtest.Model;

namespace zavtest
{
    public class MainPagePresenter
    {
        public List<steelproCategory> categories = new List<steelproCategory>();

        //**********************************************************************
        public MainPagePresenter()
        {
            loadData();
        }
        //**********************************************************************


        //Carga de los datos según modelo desde la BD o la WEB
        //**********************************************************************
        private void loadData(){
            categories.Add(new steelproCategory(1, "Manual", "Protección", "ico_guantes.png"));
            categories.Add(new steelproCategory(2, "Visual", "Protección", "ico_gafas.png"));
            categories.Add(new steelproCategory(3, "Facial", "Protección", "ico_careta.png"));
            categories.Add(new steelproCategory(4, "Auditiva", "Protección", "ico_audifonos.png"));
            categories.Add(new steelproCategory(5, "Cabeza", "Protección", "ico_casco.png"));
            categories.Add(new steelproCategory(6, "Respiratoria", "Protección", "ico_tapaboca.png"));
            categories.Add(new steelproCategory(7, "Subterranea", "Minería", "ico_mineria.png"));
            categories.Add(new steelproCategory(8, "Corporal", "Protección", "ico_chaleco.png"));
            categories.Add(new steelproCategory(9, "Out", "Lock", "ico_candado.png"));
            categories.Add(new steelproCategory(10, "Señalización", "Reflectivo", "ico_reflectivo.png"));
        }
        //**********************************************************************

    }
}
