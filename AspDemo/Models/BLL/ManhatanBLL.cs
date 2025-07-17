using AspDemo.Models.DAL;
using AspDemo.Models.Dto;
using AspDemo.Models.Entities;

namespace AspDemo.Models.BLL
{
    /// <summary>
    /// Manhatan 业务逻辑层
    /// </summary>
    public class ManhatanBLL
    {
        public List<User> GetDataNoOrm()
        {
            ManhatanDAL manhatanDAL = new ManhatanDAL();

            return manhatanDAL.GetDataNoOrm();
        }

        public List<User> GetDataWithOrm()
        {
            ManhatanDAL manhatanDAL = new ManhatanDAL();

            return manhatanDAL.GetDataWithOrm();
        }

        public object GetManhatanData()
        {
            ManhatanDAL manhatanDAL = new ManhatanDAL();

            var results = manhatanDAL.GetManhatan();

            var pmax = results.Max(a => -Math.Log10(a.P_value));
            var pmin = results.Min(a => -Math.Log10(a.P_value));

            string[] arrColor = ["#193e8f", "#ef9739", "#bebebe", "#e53528"];

            //根据chrom分组
            var groupResults = results.GroupBy(a => a.Chromosome).OrderBy(a => int.Parse(a.Key!));

            long lastPosition = 0;

            var data = new List<object> { new { type = "scatter", inherit = false } };
            List<long> tickvals = [];
            foreach (var g in groupResults)
            {
                var arrChromPosition = g.Select(a => a.Position).ToArray();

                var name = $"chr{g.Key}";
                var position = arrChromPosition.Select(a => a + lastPosition).ToArray();
                var pvalue = g.Select(a => -Math.Log10(a.P_value)).ToArray();
                var text = g.Select(a =>
                        $"PValue:{a.P_value}<br>Pos:{a.Position}<br>GeneName:{a.Gene_name}<br>Annotation:{a.Annotation}"
                    )
                    .ToArray();
                var colorIndex = (int.Parse(g.Key!) - 1) % arrColor.Length;

                var tickValue = (lastPosition + position.Max()) / 2;
                tickvals.Add(tickValue);

                lastPosition = position.Max(a => a);

                var chr = new
                {
                    mode = "markers",
                    name,
                    type = "scatter",
                    x = position,
                    y = pvalue,
                    marker = new { size = 5, color = arrColor[colorIndex] },
                    text,
                    showlegend = false,
                };
                data.Add(chr);
            }
            var layout = new
            {
                title = "Manhattan Plot",
                xaxis = new
                {
                    range = new long[] { -223469063, 2889666588 },
                    ticks = "outside",
                    title = "Chromosome",
                    autotick = false,
                    showgrid = false,
                    tickmode = "array",
                    ticktext = Enumerable.Range(1, 20).ToArray(),
                    tickvals = tickvals.ToArray(),
                },
                yaxis = new { title = "-log10(p)", range = new[] { pmin - 0.5, pmax + 1.5 } },
                shapes = new[]
                {
                    new
                    {
                        x0 = -223469063,
                        x1 = 2889666588,
                        y0 = 7.289882634888183,
                        y1 = 7.289882634888183,
                        line = new { color = "red", width = 1 },
                        type = "line",
                        xref = "x",
                        yref = "y",
                        fillcolor = "red",
                    },
                },
            };

            return new { data, layout };
        }

        public object GetTableData(PageInput<GWASListIn> input)
        {
            ManhatanDAL manhatanDAL = new ManhatanDAL();

            return manhatanDAL.GetPageTabeData(input);
        }
    }
}
