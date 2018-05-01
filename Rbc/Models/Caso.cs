using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Rbc.Models.Util;

namespace Rbc.Models
{
    public class Caso
    {
        [Column("id")]
        public int ID { get; set; }

        [Similaridade(peso = 2)]
        [Column("idade")]
        public int? Idade { get; set; }

        [Similaridade(peso = 4)]
        [Column("num_parceiros_sex")]
        [Display(Name = "Nº Parc. Sexuais")]
        public int? NumRelacoes { get; set; }

        [Similaridade(peso = 4)]
        [Column("idade_primeiro_intercurso")]
        [Display(Name = "Primeira Rel.")]
        public int? PrimeiraRelacao { get; set; }

        [Similaridade(peso = 3)]
        [Column("num_gestacoes")]
        [Display(Name = "Nº Gestações")]
        public int? NumGestacoes { get; set; }

        [Similaridade(peso = 2)]
        [Column("fumante")]
        [Display(Name = "Fuma?")]
        public bool? Fuma { get; set; }

        [Similaridade(peso = 1)]
        [Column("anos_fumante")]
        [Display(Name = "Fuma (anos)")]
        public double? NumAnosFumo { get; set; }

        [Similaridade(peso = 1)]
        [Column("macos_ano")]
        [Display(Name = "Pack/Year")]
        public double? NumMacosPorAno { get; set; }

        [Similaridade(peso = 2)]
        [Column("contraceptivos_hormonais")]
        [Display(Name = "Contraceptivo Hormonal")]
        public bool? ContraceptivoHormonal { get; set; }

        [Similaridade(peso = 2)]
        [Column("contraceptivos_hormonais_anos")]
        [Display(Name = "Contraceptivo H. (anos)")]
        public double? NumAnosContraceptivo { get; set; }

        [Similaridade(peso = 2)]
        [Display(Name = "DIU?")]
        [Column("disp_intra_uterino")]
        public bool? Diu { get; set; }

        [Similaridade(peso = 2)]
        [Column("disp_intra_uterino_anos")]
        [Display(Name = "DIU (anos)")]
        public double? NumAnosDiu { get; set; }

        [Similaridade(peso = 3)]
        [Column("dst")]
        [Display(Name = "DST?")]
        public bool? Dst { get; set; }

        [Similaridade(peso = 3)]
        [Column("num_dst")]
        [Display(Name = "Nº DST")]
        public int? NumDst { get; set; }

        [Column("codilomatose")]
        [Display(Name = "Condiloma?")]
        public bool? Condiloma { get; set; }

        [Column("codilomatose_cervical")]
        [Display(Name = "Condiloma Uterino?")]
        public bool? CondilomaUterino { get; set; }

        [Column("codilomatose_vaginal")]
        [Display(Name = "Condiloma Vaginal?")]
        public bool? CondilomaVaginal { get; set; }

        [Column("codilomatose_vulvo_perineal")]
        [Display(Name = "Condiloma Vulvo-perineal?")]
        public bool? CondilomaVulvoPerineal { get; set; }

        [Column("sifilis")]
        [Display(Name = "Sífilis?")]
        public bool? Sifilis { get; set; }

        [Column("doenca_inflamatoria_pelvica")]
        [Display(Name = "Inflamação Pélvica?")]
        public bool? InflamacaoPelvica { get; set; }

        [Column("herpes_genital")]
        [Display(Name = "Herpes Genital?")]
        public bool? HerpesGenital { get; set; }

        [Column("molusco_contagioso")]
        [Display(Name = "Molusco Contagioso?")]
        public bool? MoluscoContagioso { get; set; }

        [Column("aids")]
        [Similaridade(peso = 2)]
        [Display(Name = "AIDS?")]
        public bool? Aids { get; set; }

        [Similaridade(peso = 2)]
        [Column("hiv")]
        [Display(Name = "HIV?")]
        public bool? Hiv { get; set; }

        [Column("hepatite_b")]
        [Display(Name = "Hepatite B?")]
        public bool? HepatiteB { get; set; }

        [Similaridade(peso = 5)]
        [Column("hpv")]
        [Display(Name = "HPV?")]
        public bool? Hpv { get; set; }

        [Column("num_diagnosticos")]
        [Display(Name = "DST Nº Diag.")]
        public int? DstNumDiag { get; set; }

        [Column("anos_primeiro_diagnostico")]
        [Display(Name = "DST Anos Primeiro Diag.")]
        public double? DstAnosPrimeiroDiag { get; set; }

        [Column("anos_ultimo_diagnostico")]
        [Display(Name = "DST Anos Último Diag.")]
        public double? DstAnosUltimoDiag { get; set; }

        [Similaridade(peso = 1)]
        [Column("diagnosticado_cancer")]
        [Display(Name = "Diag. Câncer?")]
        public bool? CancerDiag { get; set; }

        [Column("diagnosticado_cin")]
        [Display(Name = "Diag. CIN?")]
        public bool? CinDiag { get; set; }

        [Similaridade(peso = 5)]
        [Column("diagnosticado_hpv")]
        [Display(Name = "Diag. HPV?")]
        public bool? HpvDiag { get; set; }

        [Column("diagnosticado")]
        [Display(Name = "Diag.?")]
        public bool? Diagnosticado { get; set; }

        [Column("colposcopia")]
        [Display(Name = "Colposcopia?")]
        public bool? Hinselmann { get; set; }

        [Column("teste_schiller")]
        [Display(Name = "Schiller?")]
        public bool? Schiller { get; set; }

        [Column("citologia_oncotica")]
        [Display(Name = "Citologia?")]
        public bool? Citologia { get; set; }

        [Column("biopsia")]
        [Display(Name = "Biópsia?")]
        public bool? Biopsia { get; set; }

        [Column("origem")]
        public OrigemCaso Origem { get; set; }

        [NotMapped]
        public double? Similaridade { get; set; }
    }

    public enum OrigemCaso
    {
        Dataset = 1,
        Aplicacao = 2
    }
}
