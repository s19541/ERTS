import { Table } from "react-bootstrap";
import { MatchDto } from "../../../services/GeneratedClient";
import LolMatchListTableRow from "./LolMatchListTableRow";

function LolMatchListTable(props: { matchList: MatchDto[] | null }) {
	const matchList = props.matchList;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>Start Time</th>
					<th style={{ textAlign: "right" }}>Blue Team</th>
					<th style={{ width: "5vh", textAlign: "center" }}>Result</th>
					<th>Red Team</th>
					<th style={{ width: "5vh", textAlign: "center" }}>Mode</th>
				</tr>
			</thead>
			<tbody>
				{matchList?.map((match, i) => (
					<LolMatchListTableRow match={match} />
				))}
			</tbody>
		</Table>
	);
}

export default LolMatchListTable;
