$(function () {
    var sportContainerSelector = '#sport-container';
    var sportResultsHub = $.connection.sportResultsHub;

    sportResultsHub.client.renderInitialSportData = function (changedDataViewModel) {     
        var $sportContainer = $(sportContainerSelector);
        $sportContainer.empty();
        appendSportContents(sportContainerSelector, changedDataViewModel);
    };

    sportResultsHub.client.updateSportData = function (changedDataViewModel) {
        for (var sportIndex = 0; sportIndex < changedDataViewModel.ChangedSports.length; sportIndex++) {
            var changedSportViewModel = changedDataViewModel.ChangedSports[sportIndex];

            updateSport(changedSportViewModel);
        }

        for (var eventIndex = 0; eventIndex < changedDataViewModel.ChangedEvents.length; eventIndex++) {
            var changedEventViewModel = changedDataViewModel.ChangedEvents[eventIndex]; 

            updateEvent(changedEventViewModel);
        }

        for (var matchIndex = 0; matchIndex < changedDataViewModel.ChangedMatches.length; matchIndex++) {
            var changedMatchViewModel = changedDataViewModel.ChangedMatches[matchIndex];

            updateMatch(changedMatchViewModel);
        }
    }

    $.connection.hub.start().done(function () {
        sportResultsHub.server.initiateFetchingSportData();
    });

    function appendSportContents(sportContainerSelector, sportViewModels) {
        for (var sportIndex = 0; sportIndex < sportViewModels.length; sportIndex++) {
            var sportViewModel = sportViewModels[sportIndex];

            appendSingleSportContents(sportContainerSelector, sportViewModel);
        }
    }

    function appendSingleSportContents(sportContainerSelector, sportViewModel) {
        var sportRowId = 'sport-row-' + sportViewModel.ID;
        jQuery('<div/>', {
            id: sportRowId,
            class: 'row'
        }).appendTo(sportContainerSelector);

        var sportNameId = 'sport-Name-' + sportViewModel.ID;
        jQuery('<div/>', {
            id: sportNameId,
            class: 'col-md-12 pb-15',
            text: sportViewModel.Name
        }).appendTo('#' + sportRowId);

        var sportEventsContainerRowId = 'sport-events-row-' + sportViewModel.ID;
        jQuery('<div/>', {
            id: sportEventsContainerRowId,
            class: 'row'
        }).appendTo(sportContainerSelector);

        var sportEventsContainerId = 'sport-events-container-' + sportViewModel.ID;
        jQuery('<div/>', {
            id: sportEventsContainerId,
            class: 'col-md-12 pl-25'
        }).appendTo('#' + sportEventsContainerRowId);

        var eventsHeaderRow = $("<div class='row header'>Events</div class='row'>" +
            "<div class='row header'>" +
            "<div class='col-md-3'>ID</div >" +
            "<div class='col-md-3'>Name</div >" +
            "<div class='col-md-3'>Is Live</div >" +
            "<div class='col-md-3'>Category ID</div >" +
            "</div class='row'>");
        $('#' + sportEventsContainerId).append(eventsHeaderRow);

        for (var eventIndex = 0; eventIndex < sportViewModel.Events.length; eventIndex++) {
            var eventViewModel = sportViewModel.Events[eventIndex];

            appendEventContents(sportEventsContainerId, eventViewModel)
        }
    }

    function appendEventContents(eventsContainerId, eventViewModel) {
        var eventRowId = 'event-row-' + eventViewModel.ID
        jQuery('<div/>', {
            id: eventRowId,
            class: 'row event-row'
        }).appendTo('#' + eventsContainerId);

        jQuery('<div/>', {
            id: 'event-col-ID-' + eventViewModel.ID,
            class: 'col-md-3',
            text: eventViewModel.ID
        }).appendTo('#' + eventRowId);

        jQuery('<div/>', {
            id: 'event-col-Name-' + eventViewModel.ID,
            class: 'col-md-3',
            text: eventViewModel.Name
        }).appendTo('#' + eventRowId);

        jQuery('<div/>', {
            id: 'event-col-IsLive-' + eventViewModel.ID,
            class: 'col-md-3',
            text: eventViewModel.IsLive ? 'Yes' : 'No'
        }).appendTo('#' + eventRowId);

        jQuery('<div/>', {
            id: 'event-Col-CategoryID-' + eventViewModel.ID,
            class: 'col-md-3',
            text: eventViewModel.CategoryID
        }).appendTo('#' + eventRowId);

        var eventMatchesContainerRowId = 'event-matches-row-' + eventViewModel.ID;
        jQuery('<div/>', {
            id: eventMatchesContainerRowId,
            class: 'row'
        }).appendTo('#' + eventsContainerId);

        var eventMatchesContainerId = 'event-matches-container-' + eventViewModel.ID;
        jQuery('<div/>', {
            id: eventMatchesContainerId,
            class: 'col-md-12 pl-25'
        }).appendTo('#' + eventMatchesContainerRowId);

        var matchesHeaderRow = $("<div class='row header'>Matches</div class='row'>" +
            "<div class='row header'>" +
            "<div class='col-md-3'>ID</div >" +
            "<div class='col-md-3'>Name</div >" +
            "<div class='col-md-3'>Start Date</div >" +
            "<div class='col-md-3'>Match Type</div >" +
            "</div class='row'>");
        $('#' + eventMatchesContainerId).append(matchesHeaderRow);

        for (var matchIndex = 0; matchIndex < eventViewModel.Matches.length; matchIndex++) {
            var matchViewModel = eventViewModel.Matches[matchIndex];

            appendMatchContents(eventMatchesContainerId, matchViewModel);
        }
    }

    function appendMatchContents(matchesContainerId, matchViewModel) {
        var matchRowId = 'match-row-' + matchViewModel.ID;
        jQuery('<div/>', {
            id: matchRowId,
            class: 'row'
        }).appendTo('#' + matchesContainerId);

        jQuery('<div/>', {
            id: 'match-col-ID-' + matchViewModel.ID,
            class: 'col-md-3',
            text: matchViewModel.ID
        }).appendTo('#' + matchRowId);

        jQuery('<div/>', {
            id: 'match-col-Name-' + matchViewModel.ID,
            class: 'col-md-3',
            text: matchViewModel.Name
        }).appendTo('#' + matchRowId);

        var startDateFormatted = moment(matchViewModel.StartDate).format('DD/MM/YYYY HH:MM:SS');

        jQuery('<div/>', {
            id: 'match-col-StartDate-' + matchViewModel.ID,
            class: 'col-md-3',
            text: startDateFormatted
        }).appendTo('#' + matchRowId);

        jQuery('<div/>', {
            id: 'match-col-MatchType-' + matchViewModel.ID,
            class: 'col-md-3',
            text: matchViewModel.MatchType
        }).appendTo('#' + matchRowId);

        var matchBetsContainerRowId = 'match-bets-row-' + matchViewModel.ID;
        jQuery('<div/>', {
            id: matchBetsContainerRowId,
            class: 'row'
        }).appendTo('#' + matchesContainerId);

        var matchBetsContainerId = 'match-bets-container-' + matchViewModel.ID;
        jQuery('<div/>', {
            id: matchBetsContainerId,
            class: 'col-md-12 pl-25'
        }).appendTo('#' + matchBetsContainerRowId);
    }

    function updateSport(changedSportViewModel) {
        if (changedSportViewModel.DisplayStatus == 0) { //add
            appendSingleSportContents(sportContainerSelector, changedSportViewModel);
        } else if (changedSportViewModel.DisplayStatus == 1) { //update
            var sportToUpdateNameSelector = '#sport-Name-' + changedSportViewModel.ID;
            $(sportToUpdateNameSelector).empty();
            $(sportToUpdateNameSelector).html(changedSportViewModel.Name);
        } else if (changedSportViewModel.DisplayStatus == 2) { //delete
            var sportToDeleteRowSelector = '#sport-row-' + changedSportViewModel.ID;
            $(sportToDeleteRowSelector).remove();
        }
    }

    function updateEvent(changedEventViewModel) {
        var eventContainerId = 'sport-events-container-' + changedEventViewModel.Sport_ID;

        if (changedEventViewModel.DisplayStatus == 0) { //add
            appendEventContents(eventContainerId, changedEventViewModel);
        } else if (changedEventViewModel.DisplayStatus == 1) { //update
            var eventToUpdateNameSelector = '#event-col-Name-' + changedEventViewModel.ID;
            $(eventToUpdateNameSelector).html(changedEventViewModel.Name);

            var eventToUpdateIsLiveSelector = '#event-col-IsLive-' + changedEventViewModel.ID;
            var isLiveString = changedEventViewModel.IsLive ? 'Yes' : 'No';
            $(eventToUpdateIsLiveSelector).html(isLiveString);

            var eventToUpdateCategoryIdSelector = '#event-Col-CategoryID-' + changedEventViewModel.ID;
            $(eventToUpdateCategoryIdSelector).html(changedEventViewModel.CategoryID);
        } else if (changedEventViewModel.DisplayStatus == 2) { //delete
            var eventToDeleteRowSelector = '#event-row-' + changedEventViewModel.ID;
            $(eventToDeleteRowSelector).remove();
        }
    }

    function updateMatch(changedMatchViewModel) {
        var matchContainerId = 'event-matches-container-' + changedMatchViewModel.Event_ID;

        if (changedMatchViewModel.DisplayStatus == 0) { //add
            appendMatchContents(matchContainerId, changedMatchViewModel);
        } else if (changedMatchViewModel.DisplayStatus == 1) { //update
            var matchToUpdateNameSelector = '#match-col-Name-' + changedMatchViewModel.ID;
            $(matchToUpdateNameSelector).empty();
            $(matchToUpdateNameSelector).html(changedMatchViewModel.Name);

            var matchToUpdateStartDateSelector = '#match-col-StartDate-' + changedMatchViewModel.ID;
            $(matchToUpdateStartDateSelector).empty();
            $(matchToUpdateStartDateSelector).html(changedMatchViewModel.StartDate);

            var matchToUpdateMatchTypeSelector = '#match-col-MatchType-' + changedMatchViewModel.ID;
            $(matchToUpdateMatchTypeSelector).empty();
            $(matchToUpdateMatchTypeSelector).html(changedMatchViewModel.MatchType);
        } else if (changedMatchViewModel.DisplayStatus == 2) { //delete
            var matchToDeleteRowSelector = '#match-row-' + changedMatchViewModel.ID;
            $(matchToDeleteRowSelector).remove();
        }
    }
})

