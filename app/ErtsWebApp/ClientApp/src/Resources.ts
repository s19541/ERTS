export default class Resources {
	public static pageAdresses = {
		home: "/",
		game: "/:gameType",
		series: "/:gameType/:leagueId",
		tournaments: "/:gameType/:leagueId/:serieId",
		lolTournamentScoreBoard: "/:gameType/:leagueId/:serieId/:tournamentId/scoreBoard",
		lolTournamentMatchList: "/:gameType/:leagueId/:serieId/:tournamentId/matches",
		lolTournamentPlayerStatsList: "/:gameType/:leagueId/:serieId/:tournamentId/playerStats",
		lolTournamentTeamStatsList: "/:gameType/:leagueId/:serieId/:tournamentId/teamStats",
		lolMatch: "/:gameType/match/:matchId",
	};
	public static buttons = {
		accept: "Akceptuję",
	};
}
