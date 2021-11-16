export default class Resources {
	public static pageAdresses = {
		home: "/",
		gameLeagues: "/:gameType/leagues",
		gameTeams: "/:gameType/teams",
		series: "/:gameType/:leagueId",
		tournaments: "/:gameType/:leagueId/:serieId",
		lolTournamentScoreBoard: "/:gameType/:leagueId/:serieId/:tournamentId/scoreBoard",
		lolTournamentMatchList: "/:gameType/:leagueId/:serieId/:tournamentId/matches",
		lolTournamentPlayerStatsList: "/:gameType/:leagueId/:serieId/:tournamentId/playerStats",
		lolTournamentTeamStatsList: "/:gameType/:leagueId/:serieId/:tournamentId/teamStats",
		lolMatch: "/:gameType/match/:matchId",
		lolGame: "/:gameType/game/:gameId",
		team: "/:gameType/team/:teamId"
	};
	public static buttons = {
		accept: "Akceptuję",
	};
}
