using SwaggerCRUDWebAPI.Model;

namespace SwaggerCRUDWebAPI.Data
{
    public interface IDAL
    {
        List<Certification> ListCertfications();
        Certification GetCertfication(string code);
        void Save(Certification cert);
        void Update(Certification cert);
        void Delete(string code);
    }
}
