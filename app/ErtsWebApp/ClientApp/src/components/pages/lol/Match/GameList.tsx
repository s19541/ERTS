import { Container, Row, Col } from "react-bootstrap";
import { LolGameShortStatsDto } from "../../../../services/GeneratedClient";
import GamePlayerStatsTable from "./GamePlayerStatsTable";
import GameTeamStats from "./GameTeamStats";
import { useHistory } from "react-router";

function GameList(props: {
	gameList: LolGameShortStatsDto[] | undefined;
}) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}
	const gameList = props.gameList;

	return (
		<Container>
			{gameList?.map((game, i) => (
				<div className="h1 text-white">
					<h1 onClick={() => redirectToPage(`/lol/game/${game.id}`)}>Game {i + 1}</h1>
					<div className="h5 text-white">
						Start Time: {game.startTime.format("HH:mm DD-MM-YYYY")} Length:{" "}
						{game.gameLength}
						<br></br>Blue Team{" "}
						{game.blueTeamStats?.teamId == game.winnerTeamId ? (
							<a style={{ color: "#145DA0" }}>Victory</a>
						) : (
							<a style={{ color: "red" }}>Defeat</a>
						)}
						<GameTeamStats teamStats={game.blueTeamStats} />
						<GamePlayerStatsTable playerStatsList={game.blueTeamPlayersStats} />
						Red Team{" "}
						{game.redTeamStats?.teamId == game.winnerTeamId ? (
							<a style={{ color: "#145DA0" }}>Victory</a>
						) : (
							<a style={{ color: "red" }}>Defeat</a>
						)}
						<GameTeamStats teamStats={game.redTeamStats} />
						<GamePlayerStatsTable playerStatsList={game.redTeamPlayersStats} />
					</div>
				</div>
			))}
		</Container>
	);
}

export default GameList;
