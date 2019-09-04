using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace XpertGroupIC.Extensiones
{
    public static class IMapperDTOExtension
    {
        /// <summary>
        ///     Método para el mapeo entre dos clases
        /// </summary>
        /// <typeparam name="TR">Origen</typeparam>
        /// <typeparam name="TA">Destino</typeparam>
        /// <param name="destino">Valor de origen</param>
        /// <returns>TA</returns>
        public static TR MapperToObject<TR, TA>(this TA destino)
            where TR : TA, new()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TA, TR>(); });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TA, TR>(destino);
        }

        /// <summary>
        ///     Extensión para mapear a un objeto
        /// </summary>
        /// <typeparam name="TR">Objeto</typeparam>
        /// <typeparam name="TA">Interface</typeparam>
        /// <param name="origen"></param>
        /// <returns>Objeto</returns>
        public static List<TR> MapperListToObject<TR, TA>(this List<TA> destino)
            where TR : TA, new()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TA, TR>(); });
            IMapper mapper = config.CreateMapper();

            return mapper.Map<List<TA>, List<TR>>(destino);
        }


        /// <summary>
        ///     Extensión para mapear a una lista de interfaces
        /// </summary>
        /// <typeparam name="TR">Objeto</typeparam>
        /// <typeparam name="TA">Interface</typeparam>
        /// <param name="origen"></param>
        /// <returns>Interface</returns>
        public static List<TA> MapperListToInterface<TR, TA>(this List<TR> origen)
            where TR : TA, new()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TR, TA>(); });
            IMapper mapper = config.CreateMapper();

            return mapper.Map<List<TR>, List<TA>>(origen);
        }

        /// <summary>
        /// Extension para mapear un diccionario a un objeto
        /// </summary>
        /// <typeparam name="T">Objeto</typeparam>
        /// <param name="origen">Diccionario</param>
        /// <returns> retorna el objeto</returns>
        public static T ToObject<T>(this IDictionary<string, object> origen)
            where T : class, new()
        {
            T objeto = new T();
            Type tipoObjeto = objeto.GetType();

            foreach (KeyValuePair<string, object> item in origen)
            {
                if (tipoObjeto.GetProperty(item.Key) != null)
                    tipoObjeto.GetProperty(item.Key).SetValue(objeto, item.Value, null);
            }

            return objeto;
        }

        /// <summary>
        /// Extencion para convertir un objeto a un DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable MapperToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
