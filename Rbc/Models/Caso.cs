using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rbc.Models
{
    public class Caso
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("idade")]
        public int? Idade { get; set; }

        [Column("num_parceiros_sex")]
        [Display(Name = "Nº Parc. Sexuais")]    
        public int? NumRelacoes { get; set; }

        [Column("idade_primeiro_intercurso")]
        [Display(Name = "Primeira Rel.")]
        public int? PrimeiraRelacao { get; set; }

        [Column("num_gestacoes")]
        [Display(Name = "Nº Gestações")]
        public int? NumGestacoes { get; set; }

        [Column("fumante")]
        [Display(Name ="Fuma?")]
        public bool? Fuma { get; set; }

        [Column("anos_fumante")]
        [Display(Name = "Fuma (anos)")]
        public double? NumAnosFumo { get; set; }

        [Column("macos_ano")]
        [Display(Name = "Pack/Year")]
        public double? NumMacosPorAno { get; set; }

        [Column("contraceptivos_hormonais")]
        [Display(Name = "Contraceptivo Hormonal")]
        public bool? ContraceptivoHormonal { get; set; }

        [Column("contraceptivos_hormonais_anos")]
        [Display(Name = "Contraceptivo H. (anos)")]
        public double? NumAnosContraceptivo { get; set; }

        [Display(Name = "DIU?")]
        [Column("disp_intra_uterino")]
        public bool? Diu { get; set; }

        [Column("disp_intra_uterino_anos")]
        [Display(Name = "DIU (anos)")]
        public double? NumAnosDiu { get; set; }

        [Column("dst")]
        [Display(Name = "DST?")]
        public bool? Dst { get; set; }

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
        [Display(Name = "AIDS?")]
        public bool? Aids { get; set; }

        [Column("hiv")]
        [Display(Name = "HIV?")]
        public bool? Hiv { get; set; }

        [Column("hepatite_b")]
        [Display(Name = "Hepatite B?")]
        public bool? HepatiteB { get; set; }

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

        [Column("diagnosticado_cancer")]
        [Display(Name = "Diag. Câncer?")]
        public bool? CancerDiag { get; set; }

        [Column("diagnosticado_cin")]
        [Display(Name = "Diag. CIN?")]
        public bool? CinDiag { get; set; }

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
