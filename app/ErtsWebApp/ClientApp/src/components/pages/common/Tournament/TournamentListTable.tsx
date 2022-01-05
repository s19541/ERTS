import { Table } from "react-bootstrap";
import { TournamentShortDto } from "../../../../services/GeneratedClient";
import TournamentListTableRow from "./TournamentListTableRow";
import { useTranslation } from "react-i18next";

interface IProps {
	tournamentList: TournamentShortDto[] | null;
	serieId: number;
}
const TournamentListTable: React.FunctionComponent<IProps> = (props) => {
	const tournaments = props.tournamentList;
	const serieId = props.serieId;
	const { t } = useTranslation();

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>{t("tournament.info.tournament-name")}</th>
					<th>{t("tournament.info.start-time")}</th>
					<th>{t("tournament.info.end-time")}</th>
				</tr>
			</thead>
			<tbody>
				{tournaments?.map((tournament, i) => (
					<TournamentListTableRow
						tournament={tournament}
						serieId={serieId}
					/>
				))}
			</tbody>
		</Table>
	);
}

export default TournamentListTable;
