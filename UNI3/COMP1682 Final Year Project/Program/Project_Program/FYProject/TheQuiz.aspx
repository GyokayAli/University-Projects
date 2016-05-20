<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TheQuiz.aspx.cs" Inherits="FYProject.TheQuiz" %>

<!DOCTYPE html>
<!--
Who Wants to Be a Millionaire Quiz Game Markup
Intended to Play a Single Game.
WWBAM materials used under fair use for academic/scholar use, should not be
distributed otherwise.

Author: Aaron Nech
-->
<html>
<head>
    <link href="http://fonts.googleapis.com/css?family=Roboto+Slab" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Quicksand:700' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" type="text/css" href="Game-Millionaire/css/style.css" />
</head>
<body>
    <audio id="background" src=''></audio>
    <audio id="rightsound" src=''></audio>
    <audio id="wrongsound" src=''></audio>
    <!-- Before the game begins problem set selection -->
    <div id="pre-start">
        <select id="problem-set"></select>
        <button id="start">Start!</button>
    </div>
    <!-- Shown when the player wins/loses -->
    <div id="game-over">
    </div>
    <!-- The actual game markup -->
    <div id="game">
        <div id="top">

            <img src="" altimg="" id="mute" data-bind="click: function() { mute() }" />

            <img src="Game-Millionaire/img/logo.jpg" id="logo" />
            <ul id="levels">
                <li class="yellow" data-bind="css: {active: level() == 15}" data-amt="1000000" data-lvl="15">$1,000,000</li>
                <li data-bind="css: {active: level() == 14}" data-amt="500000" data-lvl="14">$500,000</li>
                <li data-bind="css: {active: level() == 13}" data-amt="250000" data-lvl="13">$250,000</li>
                <li data-bind="css: {active: level() == 12}" data-amt="125000" data-lvl="12">$125,000</li>
                <li data-bind="css: {active: level() == 11}" data-amt="64000" data-lvl="11">$64,000</li>
                <li class="yellow" data-bind="css: {active: level() == 10}" data-amt="32000" data-lvl="10">$32,000</li>
                <li data-bind="css: {active: level() == 9}" data-amt="16000" data-lvl="9">$16,000</li>
                <li data-bind="css: {active: level() == 8}" data-amt="8000" data-lvl="8">$8,000</li>
                <li data-bind="css: {active: level() == 7}" data-amt="4000" data-lvl="7">$4,000</li>
                <li data-bind="css: {active: level() == 6}" data-amt="2000" data-lvl="6">$2,000</li>
                <li class="yellow" data-bind="css: {active: level() == 5}" data-amt="1000" data-lvl="5">$1,000</li>
                <li data-bind="css: {active: level() == 4}" data-amt="500" data-lvl="4">$500</li>
                <li data-bind="css: {active: level() == 3}" data-amt="300" data-lvl="3">$300</li>
                <li data-bind="css: {active: level() == 2}" data-amt="200" data-lvl="2">$200</li>
                <li data-bind="css: {active: level() == 1}" data-amt="100" data-lvl="1">$100</li>
            </ul>
            <div class="clear"></div>
        </div>
        <div id="options">
            <div id="fifty" class="options-button" data-bind="click: fifty"></div>
            <div id="phone-friend" class="options-button" data-bind="click: fadeOutOption"></div>
            <div id="audience" class="options-button" data-bind="click: fadeOutOption"></div>
            <div id="money">$<span data-bind="text: formatMoney()"></span></div>
        </div>
        <div id="question-answer-block">
            <div id="question-box" class="uibox">
                <!-- <span class="big-text">Q:</span> -->
                <span class="content" data-bind="text: getQuestionText()"></span>
            </div>
            <div id="answer-box">
                <div id="answer-one" class="answer uibox" data-bind="click: function() { answerQuestion(0, $element.id) }">
                    <span class="big-text">A:</span><span data-bind="text: getAnswerText(0)"></span>
                </div>

                <div id="answer-three" class="answer uibox" data-bind="click: function() { answerQuestion(2, $element.id) }">
                    <span class="big-text">C:</span><span data-bind="text: getAnswerText(2)"></span>
                </div>
                <div id="answer-two" class="answer uibox" data-bind="click: function() { answerQuestion(1, $element.id) }">
                    <span class="big-text">B:</span><span data-bind="text: getAnswerText(1)"></span>
                </div>
                <div id="answer-four" class="answer uibox" data-bind="click: function() { answerQuestion(3, $element.id) }">
                    <span class="big-text">D:</span><span data-bind="text: getAnswerText(3)"></span>
                </div>
            </div>
        </div>
    </div>
    <!-- Script inclusion: JQuery for effects, Knockout for MVVM, millionaire.js for application -->
    <script type="text/javascript" src="Game-Millionaire/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="Game-Millionaire/js/knockout-3.0.0.js"></script>
    <script type="text/javascript" src="Game-Millionaire/js/millionaire.js"></script>
</body>
</html>
