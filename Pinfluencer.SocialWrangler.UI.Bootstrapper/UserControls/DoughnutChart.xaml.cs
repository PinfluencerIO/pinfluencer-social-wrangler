using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.UI.Bootstrapper.UserControls
{
    public partial class DoughnutChart : UserControl
    {
        public static readonly DependencyProperty AudienceGenderProperty =
            DependencyProperty.Register( "AudienceGender",
                typeof( string ),
                typeof( DoughnutChart ),
                new PropertyMetadata( null ) );

        public DoughnutChart( )
        {
            InitializeComponent( );
            SeriesCollection.AddRange( AudienceGender.Select( x => new PieSeries
            {
                Title = x.gender.ToString(),
                Values = new ChartValues<ObservableValue> { new ObservableValue( x.count ) },
                DataLabels = false
            } ) );
        }

        public SeriesCollection SeriesCollection { get; set; }

        public IEnumerable<( GenderEnum gender, int count )> AudienceGender
        {
            get => GetValue( AudienceGenderProperty ) as IEnumerable<( GenderEnum, int )>;
            set => SetValue( AudienceGenderProperty, value );
        }
    }
}