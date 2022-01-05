import { Table } from "react-bootstrap";
import { LolTournamentPlayerStatsDto } from "../../../../services/GeneratedClient";
import LolTournamentPlayerStatsListTableRow from "./LolTournamentPlayerStatsListTableRow";
import { useTranslation } from "react-i18next";

interface IProps {
	playerStatsList: LolTournamentPlayerStatsDto[] | null;
}

const LolTournamentPlayerStatsListTable: React.FunctionComponent<IProps> = (props) => {
	const playerStatsList = props.playerStatsList;
	const { t } = useTranslation();

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th style={{ width: "3vh", textAlign: "center" }}>{t("tournament.lol.player-stats.team")}</th>
					<th style={{ width: "5vh", textAlign: "center" }}>{t("tournament.lol.player-stats.player")}</th>
					<th style={{ width: "5vh", textAlign: "center" }}>K</th>
					<th style={{ width: "5vh", textAlign: "center" }}>D</th>
					<th style={{ width: "5vh", textAlign: "center" }}>A</th>
					<th style={{ width: "5vh", textAlign: "center" }}>KDA</th>
					<th style={{ width: "5vh", textAlign: "center" }}>CS</th>
					<th style={{ width: "5vh", textAlign: "center" }}>CS/M</th>
					<th style={{ width: "5vh", textAlign: "center" }}>G</th>
					<th style={{ width: "5vh", textAlign: "center" }}>G/M</th>
					<th style={{ width: "5vh", textAlign: "center" }}>KP</th>
					<th style={{ width: "5vh", textAlign: "center" }}>DMGS</th>
					<th style={{ width: "5vh", textAlign: "center" }}>CP</th>
					<th style={{ width: "15vh", textAlign: "center" }}>{t("tournament.lol.player-stats.champs")}</th>
				</tr>
			</thead>
			<tbody>
				{playerStatsList?.map((playerStats, i) => (
					<LolTournamentPlayerStatsListTableRow playerStats={playerStats} />
				))}
			</tbody>
		</Table>
	);
}

export default LolTournamentPlayerStatsListTable;
