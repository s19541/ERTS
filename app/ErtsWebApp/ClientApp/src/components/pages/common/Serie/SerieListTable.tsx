import { Table } from "react-bootstrap";
import { SerieShortDto } from "../../../../services/GeneratedClient";
import SerieListTableRow from "./SerieListTableRow";
import { useTranslation } from "react-i18next";

interface IProps {
	serieList: SerieShortDto[] | null;
	leagueId: number;
}

const SerieListTable: React.FunctionComponent<IProps> = (props) => {
	const series = props.serieList;
	const leagueId = props.leagueId;
	const { t } = useTranslation();

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>{t("serie.serie-name")}</th>
					<th>{t("serie.start-time")}</th>
					<th>{t("serie.end-time")}</th>
				</tr>
			</thead>
			<tbody>
				{series?.map((serie, i) => (
					<SerieListTableRow
						serie={serie}
						leagueId={leagueId}
					/>
				))}
			</tbody>
		</Table>
	);
}

export default SerieListTable;
