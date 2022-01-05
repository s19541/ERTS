import { Table } from "react-bootstrap";
import { MatchShortDto } from "../../../../../services/GeneratedClient";
import LolMatchListTableRow from "./TournamentMatchListTableRow";
import { useTranslation } from "react-i18next";

interface IProps {
	matchList: MatchShortDto[] | null;
	gameType: string;
}

const TournamentMatchListTable: React.FunctionComponent<IProps> = (props) => {
	const matchList = props.matchList;
	const gameType = props.gameType;
	const { t } = useTranslation();

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>{t("tournament.matches.start-time")}</th>
					<th style={{ textAlign: "right" }}>{t("tournament.matches.blue-team")}</th>
					<th style={{ textAlign: "center" }}>{t("tournament.matches.result")}</th>
					<th>{t("tournament.matches.red-team")}</th>
					<th style={{ textAlign: "center" }}>{t("tournament.matches.mode")}</th>
				</tr>
			</thead>
			<tbody>
				{matchList?.map((match, i) => (
					<LolMatchListTableRow match={match} gameType={gameType} />
				))}
			</tbody>
		</Table>
	);
}

export default TournamentMatchListTable;
