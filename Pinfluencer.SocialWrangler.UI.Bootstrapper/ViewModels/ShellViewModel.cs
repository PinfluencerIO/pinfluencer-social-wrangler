using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.UI.Bootstrapper.Models;

namespace Pinfluencer.SocialWrangler.UI.Bootstrapper.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel( )
        {
            SeriesCollection.AddRange( AudienceGender.Select( x => new PieSeries
            {
                Title = x.gender.ToString(),
                Values = new ChartValues<ObservableValue> { new ObservableValue( x.count ) },
                DataLabels = false
            } ) );
        }

        public Func<int, string> LabelPoint { get; set; } = x => "";
        
        public PersonModel Person { get; set; } = new PersonModel
        {
            FirstName = "Aidan",
            LastName = "Gannon"
        };
        
        public SeriesCollection AudienceCountrySeries { get; set; } = new SeriesCollection
        {
            new RowSeries
            {
                Values = new ChartValues<int> { 10, 50, 39, 50 },
                MaxRowHeigth = 10
            }
        };

        public string [ ] Countries { get; set; } = { "France", "United Kingdom", "United States", "Germany" };
        
        public SeriesCollection AudienceAgeSeries { get; set; } = new SeriesCollection
        {
            new RowSeries
            {
                Values = new ChartValues<int> { 23, 50, 99, 1 },
                MaxRowHeigth = 10
            }
        };

        public string [ ] Ages { get; set; } = { "18-24", "25-36", "45-54", "60+" };

        public string MajorityAudience
        {
            get
            {
                var total = AudienceGender
                    .Sum( x => x.count );
                var max = AudienceGender
                    .Select( x => x.count )
                    .Max( );
                var perc = ( double ) max / total;
                var percentage = perc * 100;
                var ( gender, count ) = AudienceGender
                    .First( x => x.count == max );
                return $"{Math.Round( percentage, 1 )}% {gender.ToString()}";
            }
        }

        public List<( GenderEnum gender, int count )> AudienceGender { get; set; } = new List<( GenderEnum, int )>
        {
            ( GenderEnum.Male, 110 ),
            ( GenderEnum.Female, 120 )
        };

        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection( );

        public string FirstName { get; set; } = "Oliver";
    }
}