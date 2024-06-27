using System;
using System.Drawing;
using System.Windows.Forms;

namespace GamerNews
{
    public partial class Form1 : Form
    {
        private Label titleLabel;
        private Button loginButton;
        private TextBox searchBox;
        private Button searchButton;
        private ListBox suggestionList;
        private bool isSuggestionListVisible = false;
        private Label popularTitlesLabel;
        private FlowLayoutPanel popularTitlesPanel;
        private Label recentlyVisitedLabel;
        private FlowLayoutPanel recentlyVisitedPanel;
        private Label breakingNewsLabel;
        private Panel breakingNewsPanel;
        private Label featuredLabel;
        private Panel featuredPanel;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Gamer News";
            this.Size = new Size(1200, 800);

            titleLabel = new Label
            {
                Text = "Gamer News",
                Font = new Font("Arial", 24, FontStyle.Bold),
                AutoSize = true
            };

            loginButton = new Button
            {
                Text = "Login with Steam",
                Width = 150,
                Height = 30
            };

            searchBox = new TextBox
            {
                Width = 200,
                Height = 20,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            searchButton = new Button
            {
                Text = "Search",
                Width = 70,
                Height = 25,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            suggestionList = new ListBox
            {
                Width = 200,
                Height = 100,
                Visible = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            popularTitlesLabel = new Label
            {
                Text = "Popular Titles",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true
            };

            popularTitlesPanel = new FlowLayoutPanel
            {
                Width = this.ClientSize.Width / 3 - 20,
                Height = 300,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            recentlyVisitedLabel = new Label
            {
                Text = "Recently Visited",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true
            };

            recentlyVisitedPanel = new FlowLayoutPanel
            {
                Width = this.ClientSize.Width / 3 - 20,
                Height = 300,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            breakingNewsLabel = new Label
            {
                Text = "Breaking News",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true
            };

            breakingNewsPanel = new Panel
            {
                Width = 2 * (this.ClientSize.Width / 3) - 30,
                Height = 200,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle
            };

            featuredLabel = new Label
            {
                Text = "Featured",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true
            };

            featuredPanel = new Panel
            {
                Width = 2 * (this.ClientSize.Width / 3) - 30,
                Height = 400,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle
            };

            this.Controls.Add(titleLabel);
            this.Controls.Add(loginButton);
            this.Controls.Add(searchBox);
            this.Controls.Add(searchButton);
            this.Controls.Add(suggestionList);
            this.Controls.Add(popularTitlesLabel);
            this.Controls.Add(popularTitlesPanel);
            this.Controls.Add(recentlyVisitedLabel);
            this.Controls.Add(recentlyVisitedPanel);
            this.Controls.Add(breakingNewsLabel);
            this.Controls.Add(breakingNewsPanel);
            this.Controls.Add(featuredLabel);
            this.Controls.Add(featuredPanel);

            PositionControls();
            PopulatePopularTitles();
            PopulateRecentlyVisited();
            PopulateBreakingNews();
            PopulateFeatured();

            this.Resize += Form1_Resize;
            searchBox.Click += SearchBox_Click;
            searchButton.Click += SearchButton_Click;
            loginButton.Click += LoginButton_Click;
        }

        private void PositionControls()
        {
            titleLabel.Location = new Point(10, 10);
            loginButton.Location = new Point(titleLabel.Right + 20, 10);
            searchBox.Location = new Point(this.ClientSize.Width - searchBox.Width - searchButton.Width - 20, 10);
            searchButton.Location = new Point(this.ClientSize.Width - searchButton.Width - 10, 10);
            suggestionList.Location = new Point(searchBox.Left, searchBox.Bottom + 5);

            popularTitlesLabel.Location = new Point(10, 60);
            popularTitlesPanel.Location = new Point(10, popularTitlesLabel.Bottom + 10);

            recentlyVisitedLabel.Location = new Point(10, popularTitlesPanel.Bottom + 20);
            recentlyVisitedPanel.Location = new Point(10, recentlyVisitedLabel.Bottom + 10);

            breakingNewsLabel.Location = new Point(popularTitlesPanel.Right + 20, 60);
            breakingNewsPanel.Location = new Point(breakingNewsLabel.Left, breakingNewsLabel.Bottom + 10);

            featuredLabel.Location = new Point(breakingNewsLabel.Left, breakingNewsPanel.Bottom + 20);
            featuredPanel.Location = new Point(featuredLabel.Left, featuredLabel.Bottom + 10);
        }

        private void PopulatePopularTitles()
        {
            //TODO: populate with stuff from API
            PopulateImagePanel(popularTitlesPanel, new string[]
            {
                "The Legend of Zelda: Breath of the Wild",
                "Red Dead Redemption 2",
                "Elden Ring",
                "God of War",
                "Minecraft"
            });
        }

        private void PopulateRecentlyVisited()
        {
            //TODO: populate with stuff from API
            PopulateImagePanel(recentlyVisitedPanel, new string[]
            {
                "Cyberpunk 2077",
                "Hades",
                "Stardew Valley",
                "Hollow Knight",
                "Disco Elysium"
            });
        }

        private void PopulateBreakingNews()
        {
            //TODO: Populate with some story I guess 
            Label newsLabel = new Label
            {
                Text = "Major game studio announces new open-world RPG",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            breakingNewsPanel.Controls.Add(newsLabel);
        }

        private void PopulateFeatured()
        {
            //TODO: populate with some featured game
            Label featuredGameLabel = new Label
            {
                Text = "Game of the Month: Starfield",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            featuredPanel.Controls.Add(featuredGameLabel);
        }

        private void PopulateImagePanel(FlowLayoutPanel panel, string[] titles)
        {
            //TODO: populate the panes with actual images
            Color[] placeholderColors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple
            };

            for (int i = 0; i < titles.Length; i++)
            {
                Panel gamePanel = new Panel
                {
                    Width = panel.Width - 25,
                    Height = 150,
                    Margin = new Padding(0, 0, 0, 10)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Width = gamePanel.Width,
                    Height = gamePanel.Height,
                    BackColor = placeholderColors[i % placeholderColors.Length],
                    Dock = DockStyle.Fill
                };

                Label titleLabel = new Label
                {
                    Text = titles[i],
                    AutoSize = false,
                    TextAlign = ContentAlignment.BottomRight,
                    Dock = DockStyle.Bottom,
                    Height = 30,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.FromArgb(128, Color.Black),
                    ForeColor = Color.White
                };

                gamePanel.Controls.Add(pictureBox);
                gamePanel.Controls.Add(titleLabel);
                panel.Controls.Add(gamePanel);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PositionControls();
        }

        private void SearchBox_Click(object sender, EventArgs e)
        {
            ToggleSuggestionList();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //TODO: take this shit out and make it actually search
            MessageBox.Show($"Searching for: {searchBox.Text}");
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirecting to Steam login...", "Steam Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: implement the steam login
        }

        private void ToggleSuggestionList()
        {
            isSuggestionListVisible = !isSuggestionListVisible;
            suggestionList.Visible = isSuggestionListVisible;

            if (isSuggestionListVisible)
            {
                suggestionList.Items.Clear();
                //TODO: populate suggestion list
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}