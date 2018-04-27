using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rbc.Models
{
    public class Caso
    {
        public int ID { get; set; }
        public int Idade { get; set; }

        [Display(Name = "Nº Rel. Sexuais")]
        public int NumRelacoes { get; set; }

        [Display(Name = "Primeira Rel.")]
        public int PrimeiraRelacao { get; set; }

        [Display(Name = "Nº Gestações")]
        public int NumGestacoes { get; set; }

        [Display(Name ="Fuma?")]
        public bool Fuma { get; set; }

        [Display(Name = "Fuma (anos)")]
        public double NumAnosFumo { get; set; }

        [Display(Name = "Maços/Ano")]
        public double NumMacosPorAno { get; set; }

        [Display(Name = "Contraceptivo Hormonal")]
        public bool ContraceptivoHormonal { get; set; }

        [Display(Name = "Contraceptivo H. (anos)")]
        public double NumAnosContraceptivo { get; set; }

        [Display(Name = "DIU?")]
        public bool Diu { get; set; }

        [Display(Name = "DIU (anos)")]
        public double NumAnosDiu { get; set; }

        [Display(Name = "DST?")]
        public bool Dst { get; set; }

        [Display(Name = "Nº DST")]
        public int NumDst { get; set; }

        [Display(Name = "Condiloma?")]
        public bool Condiloma { get; set; }

        [Display(Name = "Condiloma Uterino?")]
        public bool CondilomaUterino { get; set; }

        [Display(Name = "Condiloma Vaginal?")]
        public bool CondilomaVaginal { get; set; }

        [Display(Name = "Condiloma Vulvo-perineal?")]
        public bool CondilomaVulvoPerineal { get; set; }

        [Display(Name = "Sífilis?")]
        public bool Sifilis { get; set; }

        [Display(Name = "Inflamação Pélvica?")]
        public bool InflamacaoPelvica { get; set; }

        [Display(Name = "Herpes Genital?")]
        public bool HerpesGenital { get; set; }

        [Display(Name = "Molusco Contagioso?")]
        public bool MoluscoContagioso { get; set; }

        [Display(Name = "AIDS?")]
        public bool Aids { get; set; }

        [Display(Name = "HIV?")]
        public bool Hiv { get; set; }

        [Display(Name = "Hepatite B?")]
        public bool HepatiteB { get; set; }

        [Display(Name = "HPV?")]
        public bool Hpv { get; set; }

        [Display(Name = "DST Nº Diag.")]
        public int DstNumDiag { get; set; }

        [Display(Name = "DST Anos Primeiro Diag.")]
        public double DstAnosPrimeiroDiag { get; set; }

        [Display(Name = "DST Anos Último Diag.")]
        public double DstAnosUltimoDiag { get; set; }

        [Display(Name = "Diag. Câncer?")]
        public bool CancerDiag { get; set; }

        [Display(Name = "Diag. CIN?")]
        public bool CinDiag { get; set; }

        [Display(Name = "Diag. HPV?")]
        public bool HpvDiag { get; set; }

        [Display(Name = "Diag.?")]
        public bool Diagnosticado { get; set; }

        [Display(Name = "Hinselmann?")]
        public bool Hinselmann { get; set; }

        [Display(Name = "Schiller?")]
        public bool Schiller { get; set; }

        [Display(Name = "Citologia?")]
        public bool Citologia { get; set; }

        [Display(Name = "Biópsia?")]
        public bool Biopsia { get; set; }

        public OrigemCaso Origem { get; set; }
    }
    public enum OrigemCaso
    {
        Dataset,
        Aplicacao
    }
}
