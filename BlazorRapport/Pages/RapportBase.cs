using BlazorRapport.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRapport.Pages
{
    public class RapportBase : ComponentBase
    {
        public string StudentSelected { get; set; } = "";
        public string[] Studenten { get; set; } = { "Kenny", "Tom", "Tim", "Claire", "Nick", "Arno", "Ken", "Mohamed", "Katia", "Gawein", "Vincent" };
        public List<Rapport[][]> Rapporten = new();
        [Inject]
        protected RapportService RapportService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            foreach (var student in Studenten)
            {
                Rapporten.Add(await RapportService.GetRapportAsync(student));
            }
        }
    }
}
