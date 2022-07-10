using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.applicationDB.models.dto
{
    public class MsDtoResponse<T>
    {
        /// <summary>
        /// Identificador de trazabilidad.
        /// </summary>
        /// <example>6ee1b7a7bcd2c7c9</example>
        public string traceid { get; set; }

        public T data { get; set; }

        public MsDtoResponse(T data, string traceId)
        {
            this.traceid = traceId;
            this.data = data;
        }
    }
}
