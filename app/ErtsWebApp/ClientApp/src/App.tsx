import React from "react";
import Navigation from "./components/fragments/Navigation";
import Home from "./components/pages/Home";
import Footer from "./components/fragments/Footer";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import Resources from "./Resources";
import LolLeagueList from "./components/pages/common/League/LeagueList";
import TournamentList from "./components/pages/common/Tournament/TournamentList";
import LolTournamentScoreBoard from "./components/pages/lol/Tournament/LolTournamentScoreBoard";
import LolTournamentMatchList from "./components/pages/lol/Tournament/LolTournamentMatchList";
import LolTournamentPlayerStatsList from "./components/pages/lol/Tournament/LolTournamentPlayerStatsList";
import MatchStats from "./components/pages/lol/Match/MatchStats";

const App: React.FunctionComponent = () => {
	document.body.style.backgroundColor = "#778899";
	return (
		<BrowserRouter>
			<Navigation />
			<Switch>
				<Route path={Resources.pageAdresses.home} exact component={Home} />
				<Route
					exact
					path={Resources.pageAdresses.lol}
					component={LolLeagueList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournaments}
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
					path={Resources.pageAdresses.lolMatch}
					component={MatchStats}
				/>
			</Switch>
			<Footer />
		</BrowserRouter>
	);
};

export default App;
