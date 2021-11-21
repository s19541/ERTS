import { Table } from "react-bootstrap";
import { TournamentTeamShortDto } from "../../../../../services/GeneratedClient";
import LolTournamentTeamTableRow from "./TournamentTeamTableRow";
import { useTranslation } from "react-i18next";

function TournamentTeamTable(props: {
	tournamentTeamList: TournamentTeamShortDto[] | null;
}) {
	const tournamentTeams = props.tournamentTeamList;
	const { t } = useTranslation();

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th style={{ width: "5vh", textAlign: "center" }}>#</th>
					<th>{t("tournament.scoreboard.team")}</th>
					<th>{t("tournament.scoreboard.matches")}</th>
					<th>{t("tournament.scoreboard.games")}</th>
				</tr>
			</thead>
			<tbody>
				{tournamentTeams?.map((tournamentTeam, i) => (
					<LolTournamentTeamTableRow
						position={i + 1}
						tournamentTeam={tournamentTeam}
					/>
				))}
			</tbody>
		</Table>
	);
}

export default TournamentTeamTable;
