$(document).ready(function () {
    var currentLangCode = 'ru';

    $('#calendar').fullCalendar({
        defaultView: 'agendaWeek',
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'agendaWeek,agendaDay,month',
        
        },
        lang: currentLangCode,
        defaultDate: '2015-12-12',
        slotDuration: '00:15:00',
        editable: false,
        eventLimit: true, // allow "more" link when too many events
        dayClick: function(date, jsEvent, view) {

            //alert('Clicked on: ' + date.format());

            //alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);

            //alert('Current view: ' + view.name);
            $('#VisitDate').val(date.format());
            // change the day's background color just for fun
            

        },
        events: [
            {
                title: 'All Day Event',
                start: '2015-12-01'
            },
            {
                title: 'Long Event',
                start: '2015-12-07',
                end: '2015-12-10'
            },
            {
                id: 999,
                title: 'Repeating Event',
                start: '2015-12-09T16:00:00'
            },
            {
                id: 999,
                title: 'Repeating Event',
                start: '2015-12-16T16:00:00'
            },
            {
                title: 'Conference',
                start: '2015-12-11',
                end: '2015-12-13'
            },
            {
                title: 'Meeting',
                start: '2015-12-12T10:30:00',
                end: '2015-12-12T12:30:00'
            },
            {
                title: 'Lunch',
                start: '2015-12-12T12:00:00'
            },
            {
                title: 'Meeting',
                start: '2015-12-12T14:30:00'
            },
            {
                title: 'Happy Hour',
                start: '2015-12-12T17:30:00'
            },
            {
                title: 'Dinner',
                start: '2015-12-12T20:00:00'
            },
            {
                title: 'Birthday Party',
                start: '2015-12-13T07:00:00'
            },
            {
                title: 'Click for Google',
                url: 'http://google.com/',
                start: '2015-12-28'
            }
        ]
    });

});

