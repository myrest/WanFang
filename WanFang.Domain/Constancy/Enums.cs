using System.ComponentModel;
namespace WanFang.Domain.Constancy
{
    public enum BoardType
    {
        Public,
        Private,
    }

    /// <summary>
    /// Dept_type 專科分類
    /// </summary>
    public enum WS_Dept_type
    {
        [Description("內科系")]
        M,

        [Description("外科系")]
        S,

        [Description("婦兒科")]
        O,

        [Description("其他專科")]
        T,

        [Description("醫療中心")]
        C,

        [Description("行政部門")]
        I,

        [Description("醫事部門")]
        E,

        [Description("教學研究部門")]
        K
    }

    /// <summary>
    /// 開放網路掛號
    /// </summary>
    public enum WS_Opd_flag
    {
        [Description("有開放")]
        Y,
        [Description("未開放")]
        N
    }
}