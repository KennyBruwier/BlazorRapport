using BlazorRapport.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRapport.Shared
{
    public class RapportComponentBase : ComponentBase
    {
        [Parameter]
        public List<Rapport[]> Rapporten { get; set; }
        [Parameter]
        public string Student { get; set; }
    }
}
