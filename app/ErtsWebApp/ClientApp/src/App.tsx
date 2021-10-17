import React from "react";
import Navigation from "./components/fragments/Navigation";
import Home from "./components/pages/Home";
import Footer from "./components/fragments/Footer";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import Resources from "./Resources";
import LeagueList from "./components/pages/common/League/LeagueList";
import TournamentList from "./components/pages/common/Tournament/TournamentList";
import SerieList from "./components/pages/common/Serie/SerieList";
import LolTournamentScoreBoard from "./components/pages/lol/Tournament/LolTournamentScoreBoard";
import LolTournamentMatchList from "./components/pages/lol/Tournament/LolTournamentMatchList";
import LolTournamentPlayerStatsList from "./components/pages/lol/Tournament/LolTournamentPlayerStatsList";
import LolTournamentTeamStatsList from "./components/pages/lol/Tournament/LolTournamentTeamStatsList";
import MatchStats from "./components/pages/lol/Match/MatchStats";
import GameStats from "./components/pages/lol/Game/GameStats";

const App: React.FunctionComponent = () => {
	document.body.style.backgroundColor = "#778899";
	return (
		<BrowserRouter>
			<Navigation />
			<Switch>
				<Route path={Resources.pageAdresses.home} exact component={Home} />
				<Route
					exact
					path={Resources.pageAdresses.lolMatch}
					component={MatchStats}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolGame}
					component={GameStats}
				/>
				<Route
					exact
					path={Resources.pageAdresses.leagues}
					component={LeagueList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.series}
					component={SerieList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.tournaments}
					component={TournamentList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentScoreBoard}
					component={LolTournamentScoreBoard}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentMatchList}
					component={LolTournamentMatchList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentPlayerStatsList}
					component={LolTournamentPlayerStatsList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentTeamStatsList}
					component={LolTournamentTeamStatsList}
				/>
			</Switch>
			<Footer />
		</BrowserRouter>
	);
};

export default App;
