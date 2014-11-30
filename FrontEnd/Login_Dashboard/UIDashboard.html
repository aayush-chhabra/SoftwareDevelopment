import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Set;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextField;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonElement;
import com.google.gson.JsonParser;

public class Exporter {

	ArrayList<JTextField> jTextArrayKey = new ArrayList<JTextField>();
	ArrayList<JTextField> jTextArrayValue = new ArrayList<JTextField>();
	JTextField contextInput = new JTextField("");
	JTextField localeInput = new JTextField("");
	JFrame mainFrame = new JFrame("Test ");

	public Exporter(ArrayList<String> one) {

		mainFrame.setLayout(new BorderLayout());
		JPanel pane = new JPanel(new GridLayout(one.size() + 3, 2));
		mainFrame.add(pane, BorderLayout.CENTER);

		pane.add(new JLabel("Enter the Context : "));
		pane.add(contextInput);

		pane.add(new JLabel("Enter the Locale : "));
		pane.add(localeInput);

		for (int i = 0; i < one.size(); i++) {
			JTextField JTextFieldTemp1 = new JTextField(one.get(i));
			JTextFieldTemp1.setEditable(false);
			jTextArrayKey.add(JTextFieldTemp1);
			pane.add(JTextFieldTemp1);

			JTextField JTextFieldTemp2 = new JTextField("");
			jTextArrayValue.add(JTextFieldTemp2);
			pane.add(JTextFieldTemp2);
		}

		pane.add(new JLabel("Do It "));

		JButton newButton = new JButton("Just Do It");

		newButton.addActionListener(new ActionListener() {

			@SuppressWarnings("unchecked")
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if (contextInput.getText().isEmpty()) {
					System.out
							.println("Please enter the context and then retry.");
					return;
				}

				if (localeInput.getText().isEmpty()) {
					System.out
							.println("Please enter the locale and then retry.");
					return;
				}

				JSONObject obj = new JSONObject();

				System.out.println("You clicked the button");
				for (int i = 0; i < jTextArrayValue.size(); i++) {
					String temp = jTextArrayValue.get(i).getText();
					if (temp.isEmpty()) {
						obj.put(jTextArrayKey.get(i).getText(), jTextArrayKey
								.get(i).getText());
					} else {
						obj.put(jTextArrayKey.get(i).getText(), jTextArrayValue
								.get(i).getText());
					}
				}

				try {
					Gson gson = new GsonBuilder().setPrettyPrinting().create();
					JsonParser jp = new JsonParser();
					JsonElement je = jp.parse(obj.toJSONString());
					String prettyJsonString = gson.toJson(je);
					FileWriter file = new FileWriter(
							"/home/sameer/Repos/ng-ui/src/iloveapps/locales/"
									+ localeInput.getText() + ".json");

					file.write(prettyJsonString);
					file.flush();
					file.close();

				} catch (IOException e) {
					e.printStackTrace();
				}

			}
		});

		pane.add(newButton);
		JScrollPane scrPane = new JScrollPane(pane);
		mainFrame.add(scrPane);
		mainFrame.pack();
		mainFrame.setVisible(true);

		for (int i = 0; i < jTextArrayKey.size(); i++) {
			System.out.println(jTextArrayKey.get(i).getText());
			System.out.println(jTextArrayValue.get(i).getText());
		}
	}

	public void start() {

	}

	public static void processIt(ArrayList<String> paths, ArrayList<String> one) {

		JSONParser parser = new JSONParser();
		for (int i = 0; i < paths.size(); i++) {
			try {
				Object obj = parser.parse(new FileReader(paths.get(i)));
				JSONObject jsonObject = (JSONObject) obj;
				@SuppressWarnings("unchecked")
				Set<String> setOne = jsonObject.keySet();
				for (String temp : setOne) {
					if (!one.contains(temp)) {
						one.add(temp);
					}
				}

			} catch (FileNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		System.out.println("Bhyaou");
	}

	public static void main(String args[]) {
		ArrayList<String> paths = new ArrayList<String>();
//		String filePath = "/home/sameer/Repos/ng-ui/src/iloveapps/rssfeed";
		String filePath = "/home/sameer/Repos/ng-ui/src/iloveapps/webvideo/apps/webvideo";
		File folder = new File(filePath);
		File[] listOfFiles = folder.listFiles();
		recurseIt(listOfFiles, paths);

		ArrayList<String> one = new ArrayList<String>();
		processIt(paths, one);

		new Exporter(one).start();
	}

	public static Boolean isDotTxt(String input) {
		if (input.endsWith(".html.txt") || input.endsWith(".ejs.txt")
				|| input.endsWith(".js.txt")) {
			return true;
		}
		return false;
	}

	public static void recurseIt(File[] listOfFiles, ArrayList<String> paths) {
		for (int i = 0; i < listOfFiles.length; i++) {
			if (listOfFiles[i].isFile()) {
				String path = listOfFiles[i].getAbsolutePath();
				if (isDotTxt(path)) {
					paths.add(path);
				}

			} else {
				if (listOfFiles[i].isDirectory()) {
					File folder = new File(listOfFiles[i].getAbsolutePath());
					File[] listOfFilesInner = folder.listFiles();
					recurseIt(listOfFilesInner, paths);
				}
			}
		}
	}

}