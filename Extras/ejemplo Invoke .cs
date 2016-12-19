
 
//Creamos el Hilo.
        Thread hilo;
        //Esta variable controlara el porcentaje de trabajo realizado por el hilo.
        private static int valor = 0;
 
        public Form1()
        {
            InitializeComponent();
            //Apuntamos el hilo al metodo que consulta los datos y hace las operaciones.
            hilo = new Thread(new ThreadStart(Datos));
        }
 
        private void btnComenzar_Click(object sender, EventArgs e)
        {
            //Iniciamos el hilo.
            hilo.Start();
        }
 
        public void Datos()
        {
            //Esta es la operacion que toma tiempo.
            //Para este ejemplo un bucle con un Sleep de 0.1 segundos.
            for (int i = 0; i < 50; i++)
            {
                //Invocamos el metodo que actualiza la barra de progreso, le pasamos como parametro el
                //numero maximo de la operacion, para el caso de la bd seria el numero maximo de registros.
                this.Progreso(50);
                Thread.Sleep(100);
 
            }
            MessageBox.Show("Termino el Proceso");
        }
 
        //Este metodo actualizara la barra de progreso.
        //retorna un int con el fin de utilizar el delegado generico Func.
        //Pero siempre retorna 0.
        public int Progreso(int Max)
        {
            //Hacemos la sincronizacion de hilos.
            //Si no estamos en el Hilo Principal.
            if (prbProgreso.Control.InvokeRequired)
            {
                //Invocamos el hilo principal.
                Func<int,int> delegado = new Func<int,int>(Progreso);
                prbProgreso.Control.Invoke(delegado,Max);
            }
            else
            {
                //Estamos en el hilo principal, actualizamos la barra de progreso y todos los 
                //elementos de la interfaz grafica.
                valor++;
                prbProgreso.Value = (valor * 100) / Max;
                lblPorcentaje.Text = prbProgreso.Value.ToString() + "%";
            }
            return 0;
        }