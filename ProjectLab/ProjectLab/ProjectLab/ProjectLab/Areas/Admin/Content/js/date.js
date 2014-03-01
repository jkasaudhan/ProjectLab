<script type="text/javascript">
    var timer = 3600, timeCont, t, timerOn = 0, timePanel
function countTimer() {
    timeCont.value = timer;
    timePanel.innerHTML = hms(timer);
    timer--;
    t = setTimeout("countTimer()", 1000);
}
function playTimer(obj) {
    if (timeCont == null || timeCont == "undefined") timeCont = document.getElementById("timerval");
    if (timePanel == null || timePanel == "undefined") timePanel = document.getElementById("timepanel");
    if (!timerOn) {
        timerOn = 1;
        countTimer();
        obj.value = timerLabel[1];
    } else {
        timerOn = 0;
        clearTimeout(t);
        obj.value = timerLabel[0];
    }
}
function hms(secs) {
    time = [0, 0, secs];
    for (var i = 2; i > 0; i--) {
        time[i - 1] = Math.floor(time[i] / 60);
        time[i] = time[i] % 60;
        if (time[i] < 10) time[i] = '0' + time[i];
    };
    return time.join(':');
}
function autoStartTimer() {
    playTimer(this);
}
window.onload = autoStartTimer;
</script>

//////////////////////////////////////////////////////view
<asp:Literal ID="litTimerLabels" runat="server"></asp:Literal>
<input type="hidden" name="timerval" id="timerval" value=""/>
<div id="timepanel" style="font-weight:bold;font-size:16px;float:left;padding:2px 20px 0 0;"></div>
<asp:Button ID="btnDoStuff" runat="server" Text="Get number of remaining seconds on server side" OnClick="btnDoStuff_Click" />


protected void btnDoStuff_Click(object sender, EventArgs e)
{
    int secondsLeft = GetSecondsLeft();
}    

private int GetSecondsLeft()
{
    int formSecondsLeft = 0;
    if (Request.Form["timerval"] != null &&
        int.TryParse(Request.Form["timerval"], out formSecondsLeft))
    {
        // Keep in mind, that this can be a negative number if more than 3600 seconds elapsed!
        return formSecondsLeft;
    }
    else
    {
        return 0;
    }
}

