import { Container, Row, Col } from "react-bootstrap";
import { LolGameShortStatsDto } from "../../../../services/GeneratedClient";
import GamePlayerStatsTable from "./GamePlayerStatsTable";
import GameTeamStats from "./GameTeamStats";

function LolMatchListTable(props: {
	gameList: LolGameShortStatsDto[] | undefined;
}) {
	const gameList = props.gameList;

	return (
		<Container>
			{gameList?.map((game, i) => (
				<div className="h1 text-white">
					Game {i + 1}
					<div className="h5 text-white">
						Start Time: {game.startTime.format("HH:mm DD-MM-YYYY")} Length:{" "}
						{game.gameLength}
						<br></br>
						Blue Team
						<GameTeamStats teamStats={game.blueTeamStats} />
						<GamePlayerStatsTable playerStatsList={game.blueTeamPlayersStats} />
						Red Team
						<GameTeamStats teamStats={game.redTeamStats} />
						<GamePlayerStatsTable playerStatsList={game.redTeamPlayersStats} />
					</div>
				</div>
			))}
		</Container>
	);
}

export default LolMatchListTable;
