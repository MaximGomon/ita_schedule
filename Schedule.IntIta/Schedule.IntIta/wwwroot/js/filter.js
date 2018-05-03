function filter() {
            var events = [];
            var arr = ["red", "green", "blue"];
    alert("I`m here");
            $.ajax({
                type: "POST",
                url: "/schedule/GetEventsForSchedule",
                success: function (data) {
                    $.each(data, function (i, v) {
                        console.log(data);
                        events.push({
                            title: v.group.name + " " + v.typeOfEvent.name + " " + v.subject.name + " " + v.room.name,
                            description: v.group.name + " " + v.subject.name + " " + v.comments,
                            group: v.group.name,
                            start: moment(v.date.startTime),
                            end: v.date.endTime != null ? moment(v.date.endTime) : null,
                            color: v.subject.color,
                            allDay: false
                        });
                    });

                    GenerateCalender(events);
                },
                error: function (error) {
                    alert('failed');
                }
            });

            function getFirstEventTime(events) {
                var currentDateTime = new Date();
                var startTimeOfCurrentYear = (new Date(currentDateTime.getFullYear(), 0, 1)).getTime();
                var currentTime = currentDateTime.getTime();
                var pastTimeOfStartCurrentYear = currentTime - startTimeOfCurrentYear;
                var hourOfMillisecs = 3600000;
                var hoursOfOneWeek = 168;
                var leftWeek = (pastTimeOfStartCurrentYear / hourOfMillisecs / hoursOfOneWeek).toFixed(2);

                var minTime = currentDateTime.getHours();

                events.forEach(function (item, i, arr) {
                    var itemTime = item.start;
                    var pastTimeOfStartCurrentYearForItem = itemTime - startTimeOfCurrentYear;
                    var leftWeekForItem = (pastTimeOfStartCurrentYearForItem / hourOfMillisecs / hoursOfOneWeek).toFixed(2);

                    if (Math.trunc(leftWeekForItem) === Math.trunc(leftWeek)) {
                        var itemDate = new Date(item.start);
                        if (itemDate.getHours() < minTime) minTime = itemDate.getHours();
                    }
                });
                return '' + minTime + ':00:00';
            }

            function GenerateCalender(events) {
                $('#calender').fullCalendar('destroy');
                $('#calender').fullCalendar({
                    contentHeight: 400,
                    defaultDate: new Date(),
                    allDaySlot: false,
                    slotDuration: '00:30:00',
                    slotLabelInterval: '00:30:00',
                    slotLabelFormat: 'HH:mm',
                    minTime: '08:00:00',
                    scrollTime: getFirstEventTime(events),

                    timeFormat: 'H:mm',
                    displayEventEnd: true,
                    defaultView: 'agendaWeek',
                    header: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'month,agendaWeek,agendaDay'
                    },
                    buttonText: {
                        agenda: 'Список'
                    },
                    eventLimit: true,
                    eventColor: '#378006',
                    events: events,
                    eventClick: function (calEvent, jsEvent, view) {
                        $('#myModal #eventTitle').text(calEvent.title);
                        var $description = $('<div/>');
                        $description.append($('<p/>')
                            .html('<b>Start: </b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));
                        if (calEvent.end != null) {
                            $description.append($('<p/>')
                                .html('<b>End: </b>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
                        }
                        $description.append($('<p/>').html('<b>Description: </b>' + calEvent.description));
                        $('#myModal #pDetails').empty().html($description);

                        $('#myModal').modal('show');
                    }
                });
            }
        }