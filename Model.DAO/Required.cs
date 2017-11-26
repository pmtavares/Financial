using System.Collections.Generic;


namespace Model.DAO
{
    public interface Required<anyClass>
    {

        void create(anyClass obj);

        void delete(anyClass obj);

        void update(anyClass obj);

        bool find(anyClass obj);

        List<anyClass> findAll();


    }
}
