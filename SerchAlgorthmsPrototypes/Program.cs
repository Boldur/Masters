using SerchAlgorthmsPrototypes;

namespace SerchAlgorthmsPrototypes
{
    public class Program
    {
        public int[,] matrix;

        [STAThread]
        static void Main()
        {
            Random rnd = new Random();
            Program program = new Program();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            int gridSize = 20;
            (int, int) start = (rnd.Next(1,gridSize -2 ), rnd.Next(1, (int)gridSize / 3));
            (int, int) goal = (rnd.Next(1, gridSize - 2), rnd.Next((int)(gridSize / 3) * 2, gridSize - 2));
            

            MapMakerScript map = new MapMakerScript(gridSize, start, goal, (5, ""), 1);
            program.matrix = map.createMatrix();

            MatrixVisualizer visualizer = new MatrixVisualizer(program.matrix);
            program.matrix[start.Item1, start.Item2] = 1;
            program.matrix[goal.Item1, goal.Item2] = 2;
            List<Node> solution;
            TreeSearch search = new TreeSearch(start, goal, program.matrix);
            string searchAlgo = "UFS";
            bool eightWay = false;

            switch (searchAlgo)
            {
                case "DFS":
                    solution = search.DFS(program.matrix, eightWay);
                    break;
                case "BFS":
                    solution = search.BFS(program.matrix, eightWay);
                    break;
                case "UFS":
                    solution = search.UFS(program.matrix, eightWay);
                    break;
                case "Astar":
                    //solution = search.ASS(program.matrix, eightWay);
                    break;
                default:
                    break;
            }
            Application.Run(visualizer);
            //Application.Run(new MatrixVisualizer(search.updatedMap));
        }

       
    }
}
