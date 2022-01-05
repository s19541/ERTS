import { Container, Row, Col } from "react-bootstrap";
import { LolGameShortStatsDto } from "../../../../services/GeneratedClient";
import GamePlayerStatsTable from "./GamePlayerStatsTable";
import GameTeamStats from "./GameTeamStats";
import { useHistory } from "react-router";
import { useTranslation } from "react-i18next";

interface IProps {
	gameList: LolGameShortStatsDto[] | undefined;
}

const GameList: React.FunctionComponent<IProps> = (props) => {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}
	const gameList = props.gameList;
	const { t } = useTranslation();

	return (
		<Container>
			{gameList?.map((game, i) => (
				<Container className="h1 text-white">
					<h1 onClick={() => redirectToPage(`/lol/game/${game.id}`)}>{t("match.game")} {i + 1}</h1>
					<h5>
						{t("match.start-time")}: {game.startTime.format("HH:mm DD-MM-YYYY")} {t("match.length")} :{" "}
						{game.gameLength}
						<br></br>{t("match.blue-team")}{" "}
						{game.blueTeamStats?.teamId == game.winnerTeamId ? (
							<a style={{ color: "#145DA0" }}>{t("match.victory")}</a>
						) : (
							<a style={{ color: "red" }}>{t("match.defeat")}</a>
						)}
						<GameTeamStats teamStats={game.blueTeamStats} />
						<GamePlayerStatsTable playerStatsList={game.blueTeamPlayersStats} />
						{t("match.red-team")}{" "}
						{game.redTeamStats?.teamId == game.winnerTeamId ? (
							<a style={{ color: "#145DA0" }}>{t("match.victory")}</a>
						) : (
							<a style={{ color: "red" }}>{t("match.defeat")}</a>
						)}
						<GameTeamStats teamStats={game.redTeamStats} />
						<GamePlayerStatsTable playerStatsList={game.redTeamPlayersStats} />
					</h5>
				</Container>
			))}
		</Container>
	);
}

export default GameList;
