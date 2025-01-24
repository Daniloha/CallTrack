using CallTrack.Share.config;
using CallTrack.Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.Filters
{
    public class CallsFilterAnalyst : CallsParameters
    {
        public long Id { get; set; } // Campo para comparação
        public SortableFields OrderBy { get; set; } // Campo para ordenação
        public bool Descending { get; set; } // Ordem decrescente

    }
}
