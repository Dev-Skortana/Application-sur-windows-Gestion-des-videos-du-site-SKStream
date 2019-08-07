using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSKStream.Services.Interfaces
{
    public interface Iservices_database<Tobjet>
    {
        String requete_sql_extraction{ get; }
        Task<Tobjet> getelement(Dictionary<String, String> donnees_critere, String operateure = "=");
        Task<List<Tobjet>> getelements(Dictionary<String, String> donnees_critere, String operateure = "=");
        Task<Boolean> update(Dictionary<String,String> donnees_modification,Dictionary<String,String> donnees_critere,String operateure = "=");
        Task<Boolean> delete(Dictionary<String, String> donnees_critere, String operateure = "=");
        Task<Boolean> insert(Dictionary<String,Object> dictionnaire_arguments_enregistrement,Boolean using_procedurestocker);
    }
}
