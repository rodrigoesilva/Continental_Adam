using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Continental.Project.Adam.UI.Models.Settings
{
    public class Model_TabActuationParameters_EvaluationParameters
    {
        public List<ActuationParameters_EvaluationParameters> lstParam_EvaluationParameters = new List<ActuationParameters_EvaluationParameters>();

        public ActuationParameters_EvaluationParameters param_EvaluationParameters = new ActuationParameters_EvaluationParameters();

        [Display(Name = "Force Scaling")]
        public string EForceScale { get; set; }

        [Display(Name = "Pressure Scaling")]
        public string EPressureScale { get; set; }

        [Display(Name = "Pressure at Force (E3)")]
        public string EP3AtForce { get; set; } //E1

        [Display(Name = "Pressure at Force (E4)")]
        public string EP4AtForce { get; set; } //E2

        [Display(Name = "Pressure at Force (E5)")]
        public string EP5AtForce { get; set; } //P1

        [Display(Name = "Pressure at Force (E6)")]
        public string EP6AtForce { get; set; } //P2

        [Display(Name = "Travel at Pressure")]
        public string EPistonTravelAtPressure { get; set; }

        [Display(Name = "Actuation Force at Pressure")]
        public string EActuationForceAtPressure { get; set; }

        [Display(Name = "Release Force Min")]
        public string EReleaseForceMin { get; set; }
        
        [Display(Name = "Release Force Max")]
        public string EReleaseForceMax { get; set; }

        [Display(Name = "Hysteresis at Pressure")]
        public string EHysteresisAtPressure { get; set; }

        [Display(Name = "Hysteresis at Pressure 2")]
        public string EHysteresisAtPressure2 { get; set; }

        [Display(Name = "Release Force at Travel")]
        public string ERelForceRemainAtTravel { get; set; }

        [Display(Name = "TMC Diameter PC")]
        public string ETMCDiameterPC { get; set; }

        [Display(Name = "TMC Diameter SC")]
        public string ETMCDiameterSC { get; set; }

        [Display(Name = "Jumper Gradient P1")]
        public string EJumperGradientP1 { get; set; }

        [Display(Name = "Jumper Gradient P2")]
        public string EJumperGradientP2 { get; set; }

        [Display(Name = "Runout Point by Linear Intersection")]
        public string CBUseLinearIntersection { get; set; }
    }

    public class ActuationParameters_EvaluationParameters
    {
        public int IdEvalParam { get; set; }
        public int IdTestAvailable { get; set; }
        public string EvalParam_GridRowType { get; set; }
        public string EvalParam_Name { get; set; }
        public string EvalParam_Caption { get; set; }
        public string EvalParam_ResultParam_Name { get; set; }
        public double EvalParam_Hi { get; set; }
        public double EvalParam_Precision { get; set; }
        public double EvalParam_Step { get; set; }
        public string EvalParam_Mksunit { get; set; }
    }
}
